using System.ComponentModel.DataAnnotations;

namespace TalSec.Models;

public class Usuario
{
    [Required(ErrorMessage = "El nombre de usuario es requerido")]
    public string Nombre { get; set; } = "";

    public int SumarUno(int numero)
    {
        int resultado;

        numero = numero + 1;
        resultado = numero;

        return resultado;
    }

    public int RestarUno(int numero)
    {
        int resultado;

        numero = numero - 1;
        resultado = numero;

        return resultado;
    }

    public int MultiplicarDos(int numero)
    {
        int resultado = numero * 2;

        return resultado;
    }

    public int SumaAleatoria(int numero)
    {
        Random rangoNumero = new Random();
        int aleatorio = rangoNumero.Next(1, 11);

        int resultado = aleatorio + numero;

        return resultado;
    }
}


