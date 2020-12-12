# 7. BBox dos círculos

E por fim, esta aplicação tem o objetivo de fazer um joystick virtual. Basicamente deve-se desenhar dois círculos (um menor e outro maior) e poder usar o mouse para mover o círculo menor, mas sem deixar ele (o centro do círculo menor) sair dos limites do círculo maior.
Para controlar o movimento do centro do círculo menor deve ser usado:
- um teste inicial pela BBox interna do círculo maior;
- seguido do cálculo da distância (euclidiana, sem raiz).

Aqui só use as classes Retangulo e Circulo para fazer as representações dos objetos abaixo.