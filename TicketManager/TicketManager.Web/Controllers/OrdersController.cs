using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TicketManager.Service.Implementation;
using TicketManager.Service.Interface;
using TicketManger.Domain.DomainModels;
using iTextSharp.text;
using System.IO;

namespace TicketManager.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IOrderService _orderService;

        public OrdersController(IShoppingCartService shoppingCartService, IOrderService orderService)
        {
            _shoppingCartService = shoppingCartService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(this._orderService.GetAll(userId));
        }

        [HttpPost]
        public IActionResult Create(int quantity)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            ShoppingCart cart = _shoppingCartService.GetShoppingCart(userId);
            Order order = new Order();
            order.UserId = userId;
            order.TicketId = cart.TicketId;
            order.Quantity = quantity;
            _orderService.Create(order);
            _shoppingCartService.ClearShoppingCart(userId);
            return RedirectToAction("Index", "Orders");
        }

        public IActionResult ExportPdf(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _orderService.Get(id.Value);
            if (order == null)
            {
                return NotFound();
            }

            Document document = new Document();

            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, Response.Body);

                document.Open();

                document.Add(new Paragraph("Order ID: " + order.Id.ToString()));
                document.Add(new Paragraph("Movie Name: " + order.Ticket.Name.ToString()));
                document.Add(new Paragraph("Movie Genre: " + order.Ticket.Genre.ToString()));
                document.Add(new Paragraph("Quantity: " + order.Quantity.ToString()));
                document.Add(new Paragraph("Total Price: " + order.getTotalPrice().ToString()));

                document.Close();

                byte[] bytes = memoryStream.ToArray();

                string contentType = "application/pdf";
                string fileName = "example.pdf";

                return File(bytes, contentType, fileName);
            }
         
        }

        [HttpGet]
        public IActionResult Export()
        {
            string fileName = "Orders.xlsx";
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workbook.Worksheets.Add("All Orders");
                worksheet.Cell(1, 1).Value = "Name";
                worksheet.Cell(1, 2).Value = "Genre";
                worksheet.Cell(1, 3).Value = "Price";
                worksheet.Cell(1, 4).Value = "Quantity";

                Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                List<Order> orders = this._orderService.GetAll(userId);

                for (int i=0; i<orders.Count; i++)
                {
                    Order order = orders[i];
                    worksheet.Cell(i+2, 1).Value = order.Ticket.Name.ToString();
                    worksheet.Cell(i+2, 2).Value = order.Ticket.Genre.ToString();
                    worksheet.Cell(i+2, 3).Value = order.getTotalPrice().ToString();
                    worksheet.Cell(i+2, 4).Value = order.Quantity.ToString();
                }

                using (var stream  = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(content, contentType, fileName);
                }

            }
        }

    }
}
