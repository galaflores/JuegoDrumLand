using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //Text mesh pro
using UnityEngine.Networking; //redes
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
// Rodrigo Alfredo Mendoza España
// Poder hacer post requests a códigos php para ingresarlos a la base de datos
public class Redes : MonoBehaviour
{
    public static Redes instance;
    private void Awake()
    {
        instance = this;
    }

    // texto de salida
    public TextMeshProUGUI resultado;

    //Referencias a la entrada de texto
    public TMP_InputField textoUsuario;
    public TMP_InputField textoPassword;
    public TMP_InputField textoFirstName;
    public TMP_InputField textoLastName;
    public TMP_Dropdown textoCountry;
    public Text textDate;
    public TMP_Dropdown sexUser;

    //estructura para los datos del usuario
    public struct DatosUsuario
    {
        public string usuario;
        public string password;
    }

    public struct DatosUsuarioRegistro
    {
        public string username;
        public string passwordUser;
        public string nameUser;
        public string lastNameUser;
        public string country;
        public int birthMonth;
        public int birthDay;
        public int birthYear;
        public string sexUser;
    }

    //estructura con atributos estaticos para mantenerlos fuera de funciones
    public struct DatosTiempo
    {
        public static string usuario;
        public static float segundosLogIn;
        public static float segundosLogOff;
    }

    public struct DatosRankingNoStatic
    {
        public string usuario;
        public int nivel;
        public int score;
        public float tiempoJugado;
    }

    //estructura para los datos del tiempo
    public struct DatosTiempoNoStatic
    {
        public string usuario;
        public float segundosLogIn;
        public float segundosLogOff;
    }

    public DatosUsuario datos;
    public DatosTiempoNoStatic tiempo;
    public DatosUsuarioRegistro datosRegistro;
    public DatosRankingNoStatic ranking;

    // Para implementar en el botón de Log in
    public void LogIn()
    {
        StartCoroutine(LogInCode());
    }

    // Mandar los datos de usuario y contraseña a la base de datos,
    // si son datos que existen dentro de ella le permite al usuario jugar
    private IEnumerator LogInCode()
    {
        string usuario = textoUsuario.text;
        string password = textoPassword.text;
        datos.usuario = usuario;
        datos.password = password;
        DatosTiempo.usuario = usuario;
        print(JsonUtility.ToJson(datos));

        WWWForm forma = new WWWForm();
        forma.AddField("datosJSON", JsonUtility.ToJson(datos));
        UnityWebRequest request = UnityWebRequest.Post("https://drumland.azurewebsites.net/validarLogInDrumLand.php", forma);
        yield return request.SendWebRequest(); //Envia los datos al servidor
        if (request.result == UnityWebRequest.Result.Success)
        {
            string texto = request.downloadHandler.text;
            if (texto == "el usuario o contraseña no son correctos")
                resultado.text = "Invalid username or password";
            else
            {
                SceneManager.LoadScene("Menu");
                DatosTiempo.segundosLogIn = Time.time;
                print(DatosTiempo.segundosLogIn);
                print(DatosTiempo.usuario);
            }

        }
        else
        {
            resultado.text = "Error al descargar: " + request.responseCode.ToString();
        }
    }

    // Para implementar el boton de Registrarse
    public void Registrarse()
    {
        StartCoroutine(RegistrarseCode());
    }
    // Manda los datos proporcionados y los agrega a la base de datos si es que no existe el usuario dentro de ella
    // Esto para que el usuario pueda hacer Log in
    private IEnumerator RegistrarseCode()
    {
        datosRegistro.username = textoUsuario.text;
        datosRegistro.passwordUser = textoPassword.text;
        datosRegistro.nameUser = textoFirstName.text;
        datosRegistro.lastNameUser = textoLastName.text;
        datosRegistro.country = textoCountry.captionText.text;
        // Separar la fecha en mes, dia y año
        string[] birthDatesArray = textDate.text.Split('/');
        datosRegistro.birthMonth = int.Parse(birthDatesArray[0]);
        datosRegistro.birthDay = int.Parse(birthDatesArray[1]);
        datosRegistro.birthYear = int.Parse(birthDatesArray[2]);
        datosRegistro.sexUser = sexUser.captionText.text;

        print(JsonUtility.ToJson(datosRegistro));
        WWWForm forma = new WWWForm();
        forma.AddField("datosJSON", JsonUtility.ToJson(datosRegistro));
        if(datosRegistro.username == "" || datosRegistro.passwordUser == "" || datosRegistro.nameUser == "" ||
            datosRegistro.lastNameUser == "" || datosRegistro.country == "Country" || datosRegistro.sexUser == "Sex")
        {
            resultado.text = "Please fill all fields";
        }
        else
        {
            UnityWebRequest request = UnityWebRequest.Post("https://drumland.azurewebsites.net/RegistrarseDB.php", forma);
            yield return request.SendWebRequest(); //Envia los datos al servidor
            if (request.result == UnityWebRequest.Result.Success)
            {
                string texto = request.downloadHandler.text;
                if (texto == "error")
                    resultado.text = "Username already exists";
                else
                    resultado.text = "Account has been successfully created, you can login now";
            }
            else
            {
                resultado.text = "Error al descargar: " + request.responseCode.ToString();
            }
        }
        
    }

    // Para mandar a la escena desde registro
    public void Regresar()
    {
        SceneManager.LoadScene("Login");
    }

    // Para mandar a la escena de registrarse
    public void botonRegistrarse()
    {
        SceneManager.LoadScene("Registro");
    }

    // para implementar en el boton de log off
    public void LogOff()
    {
        StartCoroutine(LogOffCode());
        SceneManager.LoadScene("Login");
    }

    // Envia los datos a la base de datos para agregarlos a la tabla de sesiones con el usuario,
    // el tiempo de inicio y de salida
    private IEnumerator LogOffCode()
    {
        DatosTiempo.segundosLogOff = Time.time;
        print(DatosTiempo.usuario);
        print(DatosTiempo.segundosLogOff);
        tiempo.usuario = DatosTiempo.usuario;
        tiempo.segundosLogIn = DatosTiempo.segundosLogIn;
        tiempo.segundosLogOff = DatosTiempo.segundosLogOff;
        print(JsonUtility.ToJson(tiempo));
        WWWForm forma = new WWWForm();
        forma.AddField("datosJSON", JsonUtility.ToJson(tiempo));
        UnityWebRequest request = UnityWebRequest.Post("https://drumland.azurewebsites.net/sendSessionDBDrumLand.php", forma);
        yield return request.SendWebRequest(); //Envia los datos al servidor
    }

    private bool recolectados = false;
    public void registrarRanking()
    {
        StartCoroutine(registrarRankingCode());
    }

    private IEnumerator registrarRankingCode()
    {
        if (!recolectados)
        {
            ranking.usuario = DatosTiempo.usuario;
            ranking.nivel = DatosPartida.instance.nivel;
            ranking.score = DatosPartida.instance.puntos;
            ranking.tiempoJugado = DatosPartida.instance.tiempoJugado;
            recolectados = true;
            print(JsonUtility.ToJson(ranking));
            WWWForm forma = new WWWForm();
            forma.AddField("datosJSON", JsonUtility.ToJson(ranking));
            UnityWebRequest request = UnityWebRequest.Post("https://drumland.azurewebsites.net/sendRankingDBDrumLand.php", forma);
            yield return request.SendWebRequest(); //Envia los datos al servidor
        }
    }
}
