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
    private PrimitiveType primitiveType = PrimitiveType.Points;
    private int primitiveTypeFlag = 0;
#if CG_Privado
    private Privado_SegReta obj_SegReta;
    private Privado_Circulo obj_Circulo;
#endif

        protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      camera.xmin = -300; camera.xmax = 300; camera.ymin = -300; camera.ymax = 300;

    Console.WriteLine(" --- Ajuda / Teclas: ");
    Console.WriteLine("(deslocar para esquerda): E");
    Console.WriteLine("(deslocar para direita): D");
    Console.WriteLine("(deslocar para cima): C");
    Console.WriteLine("(deslocar para baixo): B");
    Console.WriteLine("Zoom in (aproximar): I");
    Console.WriteLine("Zoom out (afastar): O");

#if CG_Privado
      obj_SegReta = new Privado_SegReta("B", null, new Ponto4D(50, 150), new Ponto4D(150, 250));
      obj_SegReta.ObjetoCor.CorR = 255; obj_SegReta.ObjetoCor.CorG = 255; obj_SegReta.ObjetoCor.CorB = 0;
      objetosLista.Add(obj_SegReta);
      objetoSelecionado = obj_SegReta;

      obj_Circulo = new Privado_Circulo("C", null, new Ponto4D(100, 300), 50);
      obj_Circulo.ObjetoCor.CorR = 0; obj_Circulo.ObjetoCor.CorG = 255; obj_Circulo.ObjetoCor.CorB = 255;
      objetosLista.Add(obj_Circulo);
      objetoSelecionado = obj_Circulo;
#endif
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
     /* else if (e.Key == Key.E)
      {
        Console.WriteLine("--- Objetos / Pontos: ");
        for (var i = 0; i < objetosLista.Count; i++)
        {
          Console.WriteLine(objetosLista[i]);
        }
      }*/
        else if (e.Key == Key.O)
        {
            camera.xmin -= 100;
            camera.xmax += 100;
            camera.ymin -= 100;
            camera.ymax += 100;            
        }
        else if (e.Key == Key.I)
        {
            if ((camera.xmin + 100) != 0)
            {
                camera.xmin += 100;
                camera.xmax -= 100;
                camera.ymin += 100;
                camera.ymax -= 100;
            }
        }
        else if (e.Key == Key.E)
        {
            camera.xmin += 20;
            camera.xmax += 20;
        }
        else if (e.Key == Key.D)
        {
            camera.xmin -= 20;
            camera.xmax -= 20;
        }
        else if (e.Key == Key.C)
        {
            camera.ymin -= 20;
            camera.ymax -= 20;
        }
        else if (e.Key == Key.B)
        {
            camera.ymin += 20;
            camera.ymax += 20;
        }
        else if (e.Key == Key.Space)
        {
            switch (primitiveTypeFlag)
            {
                case 0:
                    primitiveType = PrimitiveType.Lines;
                    primitiveTypeFlag++;
                    break;
                case 1:
                    primitiveType = PrimitiveType.LineLoop;
                    primitiveTypeFlag++;
                    break;
                case 2:
                    primitiveType = PrimitiveType.LineStrip;
                    primitiveTypeFlag++;
                    break;
                case 3:
                    primitiveType = PrimitiveType.Triangles;
                    primitiveTypeFlag++;
                    break;
                case 4:
                    primitiveType = PrimitiveType.TriangleStrip;
                    primitiveTypeFlag++;
                    break;
                case 5:
                    primitiveType = PrimitiveType.TriangleFan;
                    primitiveTypeFlag++;
                    break;
                case 6:
                    primitiveType = PrimitiveType.Quads;
                    primitiveTypeFlag++;
                    break;
                case 7:
                    primitiveType = PrimitiveType.QuadStrip;
                    primitiveTypeFlag++;
                    break;
                case 8:
                    primitiveType = PrimitiveType.Polygon;
                    primitiveTypeFlag++;
                    break;
                case 9:
                    primitiveType = PrimitiveType.Points;
                    primitiveTypeFlag = 0;
                    break;
                default:
                    break;
            }
        }
            //else if (e.Key == Key.O)
            //  bBoxDesenhar = !bBoxDesenhar;
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
      GL.Color3(Convert.ToByte(255),Convert.ToByte(0),Convert.ToByte(0));
      GL.Vertex3(0, 0, 0); GL.Vertex3(200, 0, 0);
      GL.Color3(Convert.ToByte(0), Convert.ToByte(80), Convert.ToByte(0));
      GL.Vertex3(0, 0, 0); GL.Vertex3(0, 200, 0);
      GL.End();

        GL.PointSize(6);
        GL.LineWidth(6);
        GL.Begin(primitiveType);
        GL.Color3(Convert.ToByte(0), Convert.ToByte(255), Convert.ToByte(255));
        GL.Vertex3(-200, 200, 0);
        GL.Color3(Convert.ToByte(255), Convert.ToByte(255), Convert.ToByte(0));
        GL.Vertex3(-200, -200, 0);
        GL.Color3(Convert.ToByte(0), Convert.ToByte(0), Convert.ToByte(0));
        GL.Vertex3(200, -200, 0);
        GL.Color3(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(255));
        GL.Vertex3(200, 200, 0);
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
