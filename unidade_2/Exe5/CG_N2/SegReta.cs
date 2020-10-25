/**
  Autor: Dalton Solano dos Reis
**/

using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;
using System.Collections.Generic;
using System;

namespace gcgcg
{
  internal class SegReta : ObjetoGeometria
  {
    public double anguloAtual = 0;
    public double raioAtual = 0;

    public SegReta(string rotulo, Objeto paiRef, Ponto4D pto1, Ponto4D pto2, double angulo, double raio) : base(rotulo, paiRef)
    {

      base.PontosAdicionar(pto1);
      base.PontosAdicionar(pto2);

      anguloAtual = angulo;
      raioAtual = raio;
    }

    protected override void DesenharObjeto()
    {
      GL.LineWidth(3);
      GL.Begin(base.PrimitivaTipo);

      foreach (Ponto4D pto in pontosLista)
      {
        GL.Vertex2(pto.X, pto.Y);
      }
      GL.End();
    }

    public override string ToString()
    {
      string retorno;
      retorno = "__ Objeto SegReta: " + base.rotulo + "\n";
      for (var i = 0; i < pontosLista.Count; i++)
      {
        retorno += "P" + i + "[" + pontosLista[i].X + "," + pontosLista[i].Y + "," + pontosLista[i].Z + "," + pontosLista[i].W + "]" + "\n";
      }
      return (retorno);
    }

    public void MoverEsquerda() {
      pontosLista[0].X -= 5;
      pontosLista[1].X -= 5;
    }

    public void MoverDireita() {
      pontosLista[0].X += 5;
      pontosLista[1].X += 5;
    }

    public void Aumentar() {
      raioAtual += 1;
      var pontos = Matematica.GerarPtosCirculo(anguloAtual, raioAtual);

      pontosLista[1].X = pontos.X;
      pontosLista[1].Y = pontos.Y;

    }

    public void Diminuir() {
      raioAtual -= 1;
      var pontos = Matematica.GerarPtosCirculo(anguloAtual, raioAtual);

      pontosLista[1].X = pontos.X;
      pontosLista[1].Y = pontos.Y;
    }

    public void AumentarAngulo() {
      anguloAtual = anguloAtual + 1;
      var pontos = Matematica.GerarPtosCirculo(anguloAtual, raioAtual);
      pontosLista[1].X = pontos.X;
      pontosLista[1].Y = pontos.Y;
    }

    public void DiminuirAngulo() {
      anguloAtual = anguloAtual - 1;
      var pontos = Matematica.GerarPtosCirculo(anguloAtual, raioAtual);
      pontosLista[1].X = pontos.X;
      pontosLista[1].Y = pontos.Y;
    }
  }
}