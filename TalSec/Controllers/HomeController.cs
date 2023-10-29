using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using TalSec.Models;

namespace TalSec.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public static string? nombreUsuario;
    public static int valorNumerico = 22;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        HttpContext.Session.SetString("Nombre", "Mauricio");
        nombreUsuario = HttpContext.Session.GetString("Nombre");

        if (nombreUsuario == null)
        {
            return RedirectToAction("Index");
        }

        return View();
    }

    [HttpPost("")]
    public IActionResult Index(Usuario usuario)
    {
        if (ModelState.IsValid && nombreUsuario == usuario.Nombre)
        {
            return RedirectToAction("Dashboard", usuario);
        }
        else
        {
            return View();
        }
    }

    [HttpGet("dashboard")]
    public IActionResult Dashboard()
    {
        ViewBag.Numero = valorNumerico;

        return View();
    }

    [HttpPost("dashboard")]
    public IActionResult Dashboard(Usuario usuario, string numero)
    {
        if (numero == "+Uno")
        {
            valorNumerico = usuario.SumarUno(valorNumerico);
        }
        else if (numero == "-Uno")
        {
            valorNumerico = usuario.RestarUno(valorNumerico);
        }
        else if (numero == "xDos")
        {
            valorNumerico = usuario.MultiplicarDos(valorNumerico);
        }
        else if (numero == "Random")
        {
            valorNumerico = usuario.SumaAleatoria(valorNumerico);
        }

        ViewBag.Numero = valorNumerico;

        return View();
    }

    public IActionResult LogOut()
    {
        valorNumerico = 22;

        HttpContext.Session.Clear();

        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
