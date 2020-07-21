using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NerdStore.Core.DomainObjects
{
    public class Validacoes
    {
        public static void ValidarSeIgual(object object1, object object2, string mensagem) =>
            Validar(() => object1.Equals(object2), mensagem);

        public static void ValidarSeDiferente(object object1, object object2, string mensagem) =>
            Validar(() => !object1.Equals(object2), mensagem);

        public static void ValidarSeDiferente(string pattern, string valor, string mensagem) =>
            Validar(() => !new Regex(pattern).IsMatch(valor), mensagem);

        public static void ValidarTamanho(string valor, int maximo, string mensagem) =>
            Validar(() => valor.Trim().Length > maximo, mensagem);

        public static void ValidarTamanho(string valor, int minimo, int maximo, string mensagem)
        {
            var length = valor.Trim().Length;
            Validar(() => length < minimo || length > maximo, mensagem);
        }

        public static void ValidarSeVazio(string valor, string mensagem) =>
            Validar(() => valor == null || valor.Trim().Length == 0, mensagem);

        public static void ValidarSeNulo(object object1, string mensagem) =>
            Validar(() => object1 == null, mensagem);

        public static void ValidarMinimoMaximo(double valor, double minimo, double maximo, string mensagem) =>
            Validar(() => valor < minimo || valor > maximo, mensagem);

        public static void ValidarMinimoMaximo(float valor, float minimo, float maximo, string mensagem) =>
            Validar(() => valor < minimo || valor > maximo, mensagem);

        public static void ValidarMinimoMaximo(int valor, int minimo, int maximo, string mensagem) =>
            Validar(() => valor < minimo || valor > maximo, mensagem);

        public static void ValidarMinimoMaximo(long valor, long minimo, long maximo, string mensagem) =>
            Validar(() => valor<minimo || valor> maximo, mensagem);

        public static void ValidarMinimoMaximo(decimal valor, decimal minimo, decimal maximo, string mensagem) =>
            Validar(() => valor < minimo || valor > maximo, mensagem);

        public static void ValidarSeMenorQue(long valor, long minimo, string mensagem) =>
            Validar(() => valor < minimo, mensagem);

        public static void ValidarSeMenorQue(double valor, double minimo, string mensagem) =>
            Validar(() => valor < minimo, mensagem);

        public static void ValidarSeMenorQue(decimal valor, decimal minimo, string mensagem) =>
            Validar(() => valor < minimo, mensagem);

        public static void ValidarSeMenorQue(int valor, int minimo, string mensagem) =>
            Validar(() => valor < minimo, mensagem);
        

        public static void ValidarSeFalso(bool boolvalor, string mensagem) =>
            Validar(() => !boolvalor, mensagem);

        public static void ValidarSeVerdadeiro(bool boolvalor, string mensagem) =>
            Validar(() => boolvalor, mensagem);

        private static void Validar(Func<bool> expression, string message)
        {
            if (expression())
                throw new DomainException(message);
        }
    }
}
