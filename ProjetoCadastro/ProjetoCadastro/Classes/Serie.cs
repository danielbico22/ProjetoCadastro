using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCadastro
{
    public class Serie : EntidadeBase
    {
        // atributos
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Sinopse { get; set; }
        private int Ano  { get; set; }

        private bool Excluido { get; set; }
        // métodos
        public Serie(int id, Genero genero, string titulo, string sinopse, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Sinopse = sinopse;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Sinopse: " + this.Sinopse + Environment.NewLine;
            retorno += "Ano de Produção: " + this.Ano + Environment.NewLine;
            retorno += "Excluído: " + this.Excluido;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
        
        public bool retornaExcluido()
        {
            return this.Excluido;
        }





    }

    

}
