/**
  Autor: Dalton Solano dos Reis
**/

using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;
using System;

namespace gcgcg
{
  internal class Poligono : ObjetoGeometria
  {
    public Poligono(char rotulo, Objeto paiRef) : base(rotulo, paiRef)
    {
    }

    protected override void DesenharObjeto()
    {
      GL.Begin(base.PrimitivaTipo);
      foreach (Ponto4D pto in pontosLista)
      {
        GL.Vertex2(pto.X, pto.Y);
      }
      GL.End();
    }

    //TODO: melhorar para exibir não só a lista de pontos (geometria), mas também a topologia ... poderia ser listado estilo OBJ da Wavefrom
    public override string ToString()
    {
      string retorno;
      retorno = "__ Objeto Poligono: " + base.rotulo + "\n";
      for (var i = 0; i < pontosLista.Count; i++)
      {
        retorno += "P" + i + "[" + pontosLista[i].X + "," + pontosLista[i].Y + "," + pontosLista[i].Z + "," + pontosLista[i].W + "]" + "\n";
      }
      return (retorno);
    }

    public bool estaSelecionado(double mouseX, double mouseY)
    {
      int nInt = 0;
      for (int i = 0; i < pontosLista.Count; i++)
      {
        if (i + 1 < pontosLista.Count)
        {
          double y1 = pontosLista[i].Y;
          double x1 = pontosLista[i].X;
          double y2 = pontosLista[i+1].Y;
          double x2 = pontosLista[i+1].X;
          double ti = (mouseY - y1) / (y2 - y1); // ajuda a testar se o segmento de reta atual e o Y do click do mouse tiveram interssecação
          double xi = x1 + (x2 - x1) * ti;

          if (ti >= 0 && ti <= 1 && xi > mouseX)
              nInt++;
        }
      }
      return nInt % 2 != 0;
    }

  }
}