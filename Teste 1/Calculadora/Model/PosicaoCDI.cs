using System;

namespace Calculadora.Model
{
    public class PosicaoCDI
    {
        public uint IdPosicao {get;set;}
        public DateTime DataBase { get; set; }        
        public OperacaoCDI Operacao {get;set;}
    }
}
