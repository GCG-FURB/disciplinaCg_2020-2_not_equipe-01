/**
  Autor: Dalton Solano dos Reis
**/

using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;

namespace gcgcg
{
  internal class SegReta : ObjetoGeometria
  {
    public SegReta(string rotulo, Objeto paiRef, Ponto4D pto1, Ponto4D pto2) : base(rotulo, paiRef)
    {
      base.PontosAdicionar(pto1);
      base.PontosAdicionar(pto2);
    }

    protected override void DesenharObjeto()
    {
      GL.LineWidth(2);
      GL.Begin(base.PrimitivaTipo);

      foreach (Ponto4D pto in pontosLista)
      {
        GL.Vertex2(pto.X, pto.Y);
      }
      GL.End();
    }
  }
}