using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace teste
{
    public class Cliente
    {
        private List<Contato> contatos = new List<Contato>();
        public string Nome { get; set; }
        public byte Idade { get; set; }

        public void AddContato(Contato contato)
        {
            if (contatos.Any(e => e.Numero == contato.Numero && e.TipoRelacionamento == contato.TipoRelacionamento))
                throw new Exception("Contato com mesmo numero e relacionamento ja cadastrado");
            var ultimo = contatos.LastOrDefault()?.Codigo ?? 0;
            contato.Codigo = ++ultimo;
            contatos.Add(contato);
        }
        public List<Contato> GetContatos()
        {
            return contatos.OrderBy(e => e.Codigo).ToList();
        }
        public void RemoveContato(int codigo)
        {
            var contato = contatos.FirstOrDefault(x => x.Codigo == codigo);
            if (contato == null)
            {
                Console.WriteLine("Este contato não existe!");
                return;
            }
            contatos.Remove(contato);
            
        }
    }
}


