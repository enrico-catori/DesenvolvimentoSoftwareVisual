using System;

namespace API.Models 
{
    public class Funcionario
    {
        public Funcionario()
        {
            CriadoEm = DateTime.Now;
        }
        public int id { get; set; }
        public string Nome { get; set; }
        public int Cpf { get; set; }
        public DateTime CriadoEm { get; set; }        
        public DateTime DataNascimento { get; set; }  
    }
}