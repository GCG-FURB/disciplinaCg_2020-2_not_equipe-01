/**
  Autor: Dalton Solano dos Reis
**/

using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;
using System;

namespace gcgcg
{
  internal class PrimitivaGeometrica : ObjetoGeometria
  {
    public PrimitivaGeometrica(string rotulo, Objeto paiRef, Ponto4D ptoInfEsq, Ponto4D ptoSupDir) : base(rotulo, paiRef)
    {
    }

    protected override void DesenharObjeto()
    {
      GL.PointSize(5);
      GL.Begin(base.PrimitivaTipo);
        GL.Color3((byte)0,(byte)191,(byte)255);
        GL.Vertex3(-200, 200, 0);
        GL.Color3((byte)255,(byte)255,(byte)0);
        GL.Vertex3(-200, -200, 0);
        GL.Color3((byte)0,(byte)0,(byte)0);
        GL.Vertex3(200, -200, 0);
        GL.Color3((byte)255,(byte)0,(byte)127);
        GL.Vertex3(200, 200, 0);
      GL.End();
    }

    public void MudarPrimitiva() {
      PrimitiveType [] primitivas = new [] {
        PrimitiveType.Points,
        PrimitiveType.Lines,
        PrimitiveType.LineLoop,
        PrimitiveType.LineStrip,
        PrimitiveType.TriangleStrip,
        PrimitiveType.TriangleFan,
        PrimitiveType.Quads,
        PrimitiveType.QuadStrip,
        PrimitiveType.Polygon
      };

      int random = new Random().Next(0, primitivas.Length);

      this.PrimitivaTipo = primitivas[random];
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