using Microsoft.AspNetCore.Mvc;
using SEIntern.Models;
namespace SEIntern.Controllers;
public class OrderController : Controller{
    private readonly OrderDataAccessLayer orderContext;
    private readonly IConfiguration _configuration;

    public OrderController(IConfiguration configuration)
    {
        _configuration = configuration;
        orderContext = new OrderDataAccessLayer(_configuration);
    }
    [HttpGet]
    public IActionResult Index(){
        IEnumerable<Order> orders = orderContext.GetAllOrder();  
        return View(orders); 
    }

    [HttpGet]
    public IActionResult Details(string WorkOrder){
        return View();
    }

    //CREATE
    [HttpGet]
    public IActionResult Create(){
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken] 
    public IActionResult Create(Order order){
        try{
            orderContext.AddOrder(order);  
            return RedirectToAction(nameof(Index));
        }
        catch(Exception ex){
            return View();
        }
    }

    //EDIT
    [HttpGet]
    public IActionResult Edit(string WorkOrder){
        Order order = orderContext.GetOrderData(WorkOrder);  
        return View(order); 
    }

    [HttpPost]
    [ValidateAntiForgeryToken] 
    public IActionResult Edit(Order order){
        try{
            orderContext.UpdateOrder(order);
            return RedirectToAction(nameof(Index));
        }
        catch{
            return View();
        }
    }

    //DELETE
    [HttpGet]
    public IActionResult Delete(string WorkOrder){
        Order order= orderContext.GetOrderData(WorkOrder);  
        return View(order);
    }

    [HttpPost]
    public IActionResult Delete(Order order){
        try{
            orderContext.DeleteOrder(order.WorkOrder);
            return RedirectToAction(nameof(Index));
        }
        catch{
            return View();
        }
    }

    //DELETEINSTANT
    [HttpPost]
    public IActionResult DeleteInstant(string WorkOrder){
        try{
            orderContext.DeleteOrder(WorkOrder);
            return RedirectToAction(nameof(Index));
        }
        catch{
            return View();
        }
    }
}