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
using CG_N2;

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
    Ponto4D xyMin;
    Ponto4D xyMax;
    Ponto4D pontoCirculoMaior;
    Ponto4D pontoCirculoMenor;
    int raioCirculoMaiorQuadrado = 150 * 150;
#if CG_Privado
    private Privado_SegReta obj_SegReta;
    private Privado_Circulo obj_Circulo;
#endif

        protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      camera.xmin = -400; camera.xmax = 400; camera.ymin = -400; camera.ymax = 400;

    Console.WriteLine(" --- Ajuda / Teclas: ");
    Console.WriteLine("(deslocar para esquerda): E");
    Console.WriteLine("(deslocar para direita): D");
    Console.WriteLine("(deslocar para cima): C");
    Console.WriteLine("(deslocar para baixo): B");
    Console.WriteLine("Zoom in (aproximar): I");
    Console.WriteLine("Zoom out (afastar): O");

    pontoCirculoMaior = new Ponto4D(200,200);
    pontoCirculoMenor = new Ponto4D(200, 200);

    // Círculo maior    
    obj_Circulo = new Circulo("C", null, pontoCirculoMaior, 150);
    obj_Circulo.ObjetoCor.CorR = 0; obj_Circulo.ObjetoCor.CorG = 0; obj_Circulo.ObjetoCor.CorB = 0;
    objetosLista.Add(obj_Circulo);
    

    // Círculo menor    
    obj_Circulo = new Circulo("C", null, pontoCirculoMenor, 50);
    obj_Circulo.ObjetoCor.CorR = 0; obj_Circulo.ObjetoCor.CorG = 0; obj_Circulo.ObjetoCor.CorB = 0;
    objetosLista.Add(obj_Circulo);
    objetoSelecionado = obj_Circulo;

    // BBox
    Ponto4D retanguloPontoA = Matematica.GerarPtosCirculo(45, 150);
    xyMax = new Ponto4D(pontoCirculoMaior.X + 110, pontoCirculoMaior.Y + 100);
    xyMin = new Ponto4D((pontoCirculoMaior.X * -1) + 290, (pontoCirculoMaior.Y * -1) + 300);
    obj_Retangulo = new Retangulo("R", null, xyMax, xyMin);
    obj_Retangulo.ObjetoCor.CorR = 180; obj_Retangulo.ObjetoCor.CorG = 0; obj_Retangulo.ObjetoCor.CorB = 180;
    objetosLista.Add(obj_Retangulo);

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
                if (mouseX > xyMin.X && mouseX < xyMax.X && mouseY > xyMin.Y && mouseY < xyMax.Y)
                {
                    obj_Retangulo.ObjetoCor.CorR = 180; obj_Retangulo.ObjetoCor.CorG = 0; obj_Retangulo.ObjetoCor.CorB = 180;
                } else
                {
                    obj_Retangulo.ObjetoCor.CorR = 255; obj_Retangulo.ObjetoCor.CorG = 255; obj_Retangulo.ObjetoCor.CorB = 0;
                    double compareX = mouseX - pontoCirculoMaior.X;
                    double compareY = mouseY - pontoCirculoMaior.Y;
                    if (((compareX * compareX) + (compareY * compareY)) > raioCirculoMaiorQuadrado)
                    {
                        obj_Retangulo.ObjetoCor.CorR = 0; obj_Retangulo.ObjetoCor.CorG = 255; obj_Retangulo.ObjetoCor.CorB = 255;
                        return;
                    }
                }
                objetosLista.Remove(obj_Circulo);
                pontoCirculoMenor.X = mouseX;
                pontoCirculoMenor.Y = mouseY;
                obj_Circulo = new Circulo("C", null, pontoCirculoMenor, 50);
                obj_Circulo.ObjetoCor.CorR = 0; obj_Circulo.ObjetoCor.CorG = 0; obj_Circulo.ObjetoCor.CorB = 0;
                objetosLista.Add(obj_Circulo);


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


    GL.PointSize(9);
    GL.Begin(PrimitiveType.Points);
    GL.Color3(Convert.ToByte(0), Convert.ToByte(0), Convert.ToByte(0));
    GL.Vertex3(pontoCirculoMenor.X, pontoCirculoMenor.Y,0);
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
