using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;
using System;

namespace gcgcg
{
  internal class Circulo : ObjetoGeometria
  {
    private Ponto4D pontoCentro;
    public Ponto4D PontoCentro  { get => pontoCentro; set => pontoCentro = value; }
    private int numeroPontos;
    private int raio;
    public int Raio { get => raio; }

    public Circulo(string rotulo, Objeto paiRef, int numPontos, int raioCirculo, Ponto4D ptoCentro) : base(rotulo, paiRef)
    {
      PontoCentro = ptoCentro;
      numeroPontos = numPontos;
      raio = raioCirculo;
    }

    protected override void DesenharObjeto()
    {
      var incrementoAngulo = 360 / numeroPontos;
      Ponto4D ponto;

      GL.LineWidth(2);
      GL.Begin(base.PrimitivaTipo);

      for(int angulo = 0; angulo <= 360; angulo+=incrementoAngulo) {
        ponto = Matematica.GerarPtosCirculo(angulo, raio) + PontoCentro;
        GL.Vertex3(ponto.X, ponto.Y, 0);
      }

      GL.End();
      GL.PointSize(5);
      GL.Begin(PrimitiveType.Points);
      GL.Vertex3(pontoCentro.X, pontoCentro.Y, 0);
      GL.End();
    }
  }
}