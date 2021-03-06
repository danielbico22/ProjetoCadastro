using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCadastro.Interface
{
    internal interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T objeto);
        void Exclui(int id);
        void Atualiza(int id, T objeto);
        int ProximoId();
    }
}
