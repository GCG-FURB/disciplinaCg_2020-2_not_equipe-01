/**
  Autor: Dalton Solano dos Reis
**/

using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;

namespace gcgcg
{
  internal class Circulo : ObjetoGeometria
  {
    public Circulo(string rotulo, Objeto paiRef, int numeroPontos, int raio, Ponto4D ptoCentro) : base(rotulo, paiRef)
    {
      var incrementoAngulo = 360 / numeroPontos;

      for(int angulo = 0; angulo <= 360; angulo+=incrementoAngulo) {
        base.PontosAdicionar(Matematica.GerarPtosCirculo(angulo, raio) + ptoCentro);
       }
    }

    protected override void DesenharObjeto()
    {
      GL.PointSize(5);
      GL.Begin(PrimitiveType.Points);

      foreach (Ponto4D pto in pontosLista)
      {
        GL.Vertex3(pto.X, pto.Y, 0);
      }
      GL.End();
    }

    //TODO: melhorar para exibir não só a lsita de pontos (geometria), mas também a topologia ... poderia ser listado estilo OBJ da Wavefrom
    public override string ToString()
    {
      string retorno;
      retorno = "__ Objeto Circulo: " + base.rotulo + "\n";
      for (var i = 0; i < pontosLista.Count; i++)
      {
        retorno += "P" + i + "[" + pontosLista[i].X + "," + pontosLista[i].Y + "," + pontosLista[i].Z + "," + pontosLista[i].W + "]" + "\n";
      }
      return (retorno);
    }

  }
}