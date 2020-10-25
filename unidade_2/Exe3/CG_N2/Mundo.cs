/**
  Autor: Dalton Solano dos Reis
**/

#define CG_Gizmo
// #define CG_Privado

using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using OpenTK.Input;
using CG_Biblioteca;

namespace gcgcg
{
  class Mundo : GameWindow
  {
    private static Mundo instanciaMundo = null;

    private Mundo(int width, int height) : base(width, height) { }

    public static Mundo GetInstance(int width, int height)
    {
      if (instanciaMundo == null)
        instanciaMundo = new Mundo(width, height);
      return instanciaMundo;
    }

    private CameraOrtho camera = new CameraOrtho();
    protected List<Objeto> objetosLista = new List<Objeto>();
    private ObjetoGeometria objetoSelecionado = null;
    private bool bBoxDesenhar = false;
    int mouseX, mouseY;   //TODO: achar método MouseDown para não ter variável Global
    private bool mouseMoverPto = false;
    private Circulo obj_Circulo;
    private Retangulo obj_Retangulo;
    private SegReta obj_SegReta1;
    private SegReta obj_SegReta2;
    private SegReta obj_SegReta3;

#if CG_Privado
    private Privado_SegReta obj_SegReta;
    private Privado_Circulo obj_Circulo;
#endif

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      camera.xmin = -300; camera.xmax = 300; camera.ymin = -300; camera.ymax = 300;

      obj_SegReta1 = new SegReta("A", null, new Ponto4D(0, 100), new Ponto4D(100, -100));
      obj_SegReta1.ObjetoCor.CorR = 135; obj_SegReta1.ObjetoCor.CorG = 206; obj_SegReta1.ObjetoCor.CorB = 235;
      objetosLista.Add(obj_SegReta1);
      objetoSelecionado = obj_SegReta1;

      obj_SegReta2 = new SegReta("B", null, new Ponto4D(100, -100), new Ponto4D(-100, -100));
      obj_SegReta2.ObjetoCor.CorR = 135; obj_SegReta2.ObjetoCor.CorG = 206; obj_SegReta2.ObjetoCor.CorB = 235;
      objetosLista.Add(obj_SegReta2);
      objetoSelecionado = obj_SegReta2;

      obj_SegReta2 = new SegReta("C", null, new Ponto4D(-100, -100), new Ponto4D(0, 100));
      obj_SegReta2.ObjetoCor.CorR = 135; obj_SegReta2.ObjetoCor.CorG = 206; obj_SegReta2.ObjetoCor.CorB = 235;
      objetosLista.Add(obj_SegReta2);
      objetoSelecionado = obj_SegReta2;

      obj_Circulo = new Circulo("D", null, 72, 100, new Ponto4D(100,-100));
      obj_Circulo.ObjetoCor.CorR = 0; obj_Circulo.ObjetoCor.CorG = 0; obj_Circulo.ObjetoCor.CorB = 0;
      objetosLista.Add(obj_Circulo);
      objetoSelecionado = obj_Circulo;

      obj_Circulo = new Circulo("E", null, 72, 100, new Ponto4D(-100,-100));
      obj_Circulo.ObjetoCor.CorR = 0; obj_Circulo.ObjetoCor.CorG = 0; obj_Circulo.ObjetoCor.CorB = 0;
      objetosLista.Add(obj_Circulo);
      objetoSelecionado = obj_Circulo;

      obj_Circulo = new Circulo("F", null, 72, 100, new Ponto4D(0,100));
      obj_Circulo.ObjetoCor.CorR = 0; obj_Circulo.ObjetoCor.CorG = 0; obj_Circulo.ObjetoCor.CorB = 0;
      objetosLista.Add(obj_Circulo);
      objetoSelecionado = obj_Circulo;

      GL.ClearColor(0.5f,0.5f,0.5f,1.0f);
    }
    protected override void OnUpdateFrame(FrameEventArgs e)
    {
      base.OnUpdateFrame(e);
      GL.MatrixMode(MatrixMode.Projection);
      GL.LoadIdentity();
      GL.Ortho(camera.xmin, camera.xmax, camera.ymin, camera.ymax, camera.zmin, camera.zmax);
    }
    protected override void OnRenderFrame(FrameEventArgs e)
    {
      base.OnRenderFrame(e);
      GL.Clear(ClearBufferMask.ColorBufferBit);
      GL.MatrixMode(MatrixMode.Modelview);
      GL.LoadIdentity();
#if CG_Gizmo
      Sru3D();
#endif
      for (var i = 0; i < objetosLista.Count; i++)
        objetosLista[i].Desenhar();
      if (bBoxDesenhar && (objetoSelecionado != null))
        objetoSelecionado.BBox.Desenhar();
      this.SwapBuffers();
    }

    protected override void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
    {
      if (e.Key == Key.H)
        Utilitario.AjudaTeclado();
      else if (e.Key == Key.Escape)
        Exit();
      else if (e.Key == Key.E)
      {
        Console.WriteLine("--- Objetos / Pontos: ");
        for (var i = 0; i < objetosLista.Count; i++)
        {
          Console.WriteLine(objetosLista[i]);
        }
      }
      else if (e.Key == Key.O)
        bBoxDesenhar = !bBoxDesenhar;
      else if (e.Key == Key.V)
        mouseMoverPto = !mouseMoverPto;   //TODO: falta atualizar a BBox do objeto
      else
        Console.WriteLine(" __ Tecla não implementada.");
    }

    //TODO: não está considerando o NDC
    protected override void OnMouseMove(MouseMoveEventArgs e)
    {
      mouseX = e.Position.X; mouseY = 600 - e.Position.Y; // Inverti eixo Y
      if (mouseMoverPto && (objetoSelecionado != null))
      {
        objetoSelecionado.PontosUltimo().X = mouseX;
        objetoSelecionado.PontosUltimo().Y = mouseY;
      }
    }

#if CG_Gizmo
    private void Sru3D()
    {
      GL.LineWidth(3);
      GL.Begin(PrimitiveType.Lines);
      GL.Color3((byte)255,(byte)0,(byte)0);
      GL.Vertex3(0, 0, 0); GL.Vertex3(200, 0, 0);
      GL.Color3((byte)0,(byte)255,(byte)0);
      GL.Vertex3(0, 0, 0); GL.Vertex3(0, 200, 0);
      GL.Color3((byte)0,(byte)0,(byte)255);
      GL.End();
    }
#endif
  }
  class Program
  {
    static void Main(string[] args)
    {
      Mundo window = Mundo.GetInstance(600, 600);
      window.Title = "CG_N2";
      window.Run(1.0 / 60.0);
    }
  }
}
