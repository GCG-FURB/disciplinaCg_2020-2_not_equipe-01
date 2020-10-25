using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;
using System.Collections.Generic;
using System;

namespace gcgcg
{
  internal class Spline : ObjetoGeometria
  {
    private List<Ponto4D> pontosControle;
    private double quantidadePontos;
    public double QuantidadePontos {
      get => quantidadePontos;
      set
      {
        if (value >= 1) {
          quantidadePontos = value;
        }
      }
    }
    public Spline(string rotulo, Objeto paiRef, List<Ponto4D> pontosControle, double quantidadePontos) : base(rotulo, paiRef)
    {
      Console.WriteLine(quantidadePontos);
      this.pontosControle = pontosControle;
      QuantidadePontos = quantidadePontos;
    }

    protected override void DesenharObjeto()
    {
      Ponto4D pontoAtual;
      double variacaoT = 1/quantidadePontos;

      GL.LineWidth(1);
      GL.Begin(PrimitiveType.LineStrip);
      GL.Color3((byte)255,(byte)255,(byte)0);

      for(double t = 0; t<=1;t+=variacaoT)
      {
        pontoAtual = calcularPonto(t);
        GL.Vertex2(pontoAtual.X, pontoAtual.Y);
      }

      GL.End();
    }

    private Ponto4D calcularPonto(double t) {
      double pesoP0 = Math.Pow((1-t), 3);
      double pesoP1 = 3 * t * Math.Pow((1-t), 2);
      double pesoP2 = 3 * Math.Pow(t,2) * (1-t);
      double pesoP3 = Math.Pow(t,3);
      double x = (pesoP0 * pontosControle[0].X) + (pesoP1 * pontosControle[1].X) + (pesoP2 * pontosControle[2].X) + (pesoP3 * pontosControle[3].X);
      double y = (pesoP0 * pontosControle[0].Y) + (pesoP1 * pontosControle[1].Y) + (pesoP2 * pontosControle[2].Y) + (pesoP3 * pontosControle[3].Y);

      return new Ponto4D(x,y);
    }
  }
}