# GDD

![alt text](https://github.com/AtaraxiaDevs/breakfast/blob/main/GDD/LogoAtaraxia/logo_definitivo.png)



## CONTACTO
#### [WEB: Ataraxia Devs](https://ataraxiadevs.github.io/)
#### [TWITTER: @AtaraxiaDevs](https://twitter.com/AtaraxiaDevs?s=08)
#### [YOUTUBE: https://www.youtube.com/watch?v=YqdJcBMMgJw](https://www.youtube.com/channel/UCf6IyOGVFrC8l-6_nfMpzhQ)

<br></br>
<hr></hr>
<br></br>


# INDICE

## [1.- FICHA RESUMEN	](#fichaResumen)
## [2.- HISTORIAL DE VERSIONES](#historialDeVersiones)
## [3.- SINOPSIS DEL JUEGO](#sinopsisDelJuego)
## [4.- CARACTERÍSTICAS PRINCIPALES](#caracteristicasPrincipales)	
## [5.- DISEÑO DEL JUEGO](#diseñoDelJuego)		
### [5.1.- MECÁNICAS](#mecanicas)
#### [5.1.1.- SISTEMA](#mecanicas1)
#### [5.1.2.- VEHÍCULOS](#mecanicas2)
#### [5.1.3.- SIGNOS DEL ZODIACO](#mecanicas3)
#### [5.1.4.- REGLAJES](#mecanicas4)
#### [5.1.5.- CIRCUITOS](#mecanicas5)
#### [5.1.6.- CONSTRUCTOR](#mecanicas6)
### [5.2.- ESTADOS JUEGO](#estadosJuego)
### [5.3.- INTERFACES](#interfaces)
### [5.4.- CONTROLES](#controles)
### [5.5.- PROGRESO DEL JUEGO](#progresoDelJuego)
### [5.6.- MODOS DE JUEGO](#niveles)
## [6.- DISEÑO DEL MUNDO](#diseñoDelMundo)
### [6.1.- PERSONAJES](#personajes)
### [6.2.- LOCALIZACIONES](#localizaciones)
## [7.- ARTE](#arte)
### [7.1.- ESTILO Y REFERENCIAS](#estiloYReferncias)
### [7.2.- ARTE FINAL](#arteFinal)
### [7.3.- ARTE PROMOCIONAL](#artePromocional)
## [8.- SONIDO](#sonido)	
### [8.1.- BANDA SONORA](#bandaSonora)	
### [8.2.- EFECTOS DE SONIDO](#efectosDeSonido)
## [9.- NARRATIVA Y GUION](#narrativaYGuion)	
### [9.1.- SINOPSIS](#sinopsis)
## [10.- DETALLES DE PRODUCCIÓN](#detallesDeProduccion)
### [10.1.- MIEMBROS DEL EQUIPO](#miembrosDelEquipo)
### [10.2.- CICLO DE VIDA](#cicloDeVida)
### [10.3.- MODELO DE NEGOCIO](#modeloDeNegocio)
### [10.4.- MARKETING](#marketing)
## [11.- POST MORTEM](#postMortem)
### [11.1 - RETROSPECTIVA PERSONAL](#retroPersonal)
#### [11.1.1 - DANIEL AYLLÓN PEINADO](#danielAyllonPeinado)
#### [11.1.2 - PABLO GARCÍA SÁNCHEZ](#pabloGarciaSanchez)
#### [11.1.3 - CELTIA MARTÍN GARCÍA](#celtiaMartinGarcia)
#### [11.1.4 - DANIEL MUÑOZ RIVERA](#danielMunozRivera)
#### [11.1.5 - ALBERTO SÁNCHEZ MATEO](#albertoSanchezMateo)
#### [11.1.6 - WEI ZHENG](#weiZheng)
### [11.2 - RETROSPECTIVA GRUPAL](#retroGrupal)
#### [11.2.1 - PUNTOS FUERTES](#puntosFuertes)
#### [11.2.2 - PUNTOS DÉBILES](#puntosDebiles)
### [11.3 - EXTERNOS](#externos)
#### [11.3.1 - USUARIO CASUAL](#usuarioCasual)
### [11.4 - ¿HEMOS MEJORADO?](#hemosMejorado)

---
---

## 1.- FICHA RESUMEN <a name="fichaResumen"/>

| **NOMBRE**      | Constela-Trix   |
| :-------------: | :---------------------:  |
| **VERSION**     | 1.0                      |
| **GENERO**      | Carreras                 |
| **TEMÁTICA**    | Espacio                  |
| **PLATAFORMA**  | Web (PC, Móvil o Tablet) |
| **JUEGOS RELACIONADOS**  | Slot Racing, Motorsport Manager |
| **PUBLICO OBJETIVO**     | Jóvenes adultos. Fans de la Fórmula 1      |
| **ESTILO VISUAL**        | 3D           |
| **CALIFICACIÓN**         | PEGI 3+                 |
| **IDIOMA**      | Español, Inglés, Gallego          |
| **VISTA**       | Tercera persona              |
| **TECNOLOGÍAS** | Unity                   |
| **MECÁNICAS**   | - Compite contra otros vehículos <br> - Construye tu propio circuito <br>- Comparte tus circuitos con el mundo |

---

## 2.- HISTORIAL DE VERSIONES <a name="historialDeVersiones"/>

| **VERSION**     | **CAMBIOS DE VERSION**  |
| :-------------: |:---------------------:  |
| 1.0             | Versión Inicial         |

---
 
## 3.- SINOPSIS DEL JUEGO <a name="sinopsisDelJuego"/>

> ¡Bienvenidos a una nueva edición de Constela-Trix, la carrera más espectacular de todo el universo! ¿Qué nave te llevará al éxito interplanetario? Escoge con cabeza los mejores signos del Zodiaco y arrasa con todos los que se encuentren en tu camino.

> Constela-Trix es un juego de carreras en el que tendrás que ser el más rápido para poder triunfar en solitario contra enemigos controlados por IA. Escoge una nave entre cuatro posibilidades: aire, agua, fuego y tierra y equípate dos de los doce signos del Zodiaco para alterar las características de tu vehículo. Puedes competir en los circuitos básicos o crear tus propios recorridos mediante el editor de circuitos. Además, podrás compartir estos niveles mediante un código.

---

## 4.- CARACTERÍSTICAS PRINCIPALES <a name="caracteristicasPrincipales"/>

**- Diferentes tipos de carreras:** Al iniciar el juego, los jugadores podrán escoger entre una serie de modos de juego:

  *+ Partida rápida:* En este modo de juego se elegirá un circuito, tanto básicos como creados por los jugadores. El circuito puede ser escogido de forma aleatoria entre todos los disponibles o importarlo directamente. Una vez elegido, los jugadores podrán empezar a competir, siendo el objetivo acabar la carrera antes que el resto de competidores. Las naves se moverán mediante un camino predeterminado y los jugadores solo podrán controlar la velocidad de su vehículo mediante una barra desplazadora.
 
  *+ Modo liga:* En este modo se elegirán una serie de circuitos de forma aleatoria, los cuales se jugarán de forma continuada. En el último circuito se elegirá al ganador de la temporada, siendo el jugador que más puntos haya acumulado.
 
  *+ Mi equipo:* El competidor se enfrentará a tres naves controladas por IA, pero no podrá controlar la velocidad de su propia nave. Para poder triunfar tendrá que ajustar su vehículo de la mejor forma posible para maximizar las capacidades según el circuito antes de empezar la partida.
 
**- Naves:** Antes de empezar una partida, los jugadores podrán elegir una nave entre los cuatro tipos disponibles: aire, agua, fuego y tierra. Cada una de estas naves dispondrá de unas características iniciales distintas y podrá circular mejor en módulos afines a su elemento. Además, cada nave podrá equiparse dos signos del Zodiaco, los cuales aumentarán o disminuirán ciertas características de los vehículos.

**- Editor de circuitos:** Los jugadores tendrán a su disposición un editor de circuitos por módulos. Existen distintos tipos de módulos: recta, curva, ... pudiendo girarlos y conectarlos entre sí para crear circuitos únicos. Estos circuitos se podrán compartir con cualquier persona que tenga el juego mediante códigos. Además, todos los circuitos serán subidos automáticamente a una base de datos para poder ser usados en cualquier modo de juego y por cualquier jugador.

---

## 5.- DISEÑO DEL JUEGO	 <a name="diseñoDelJuego"/>
### 5.1.- MECÁNICAS			   <a name="mecanicas"/>
#### 5.1.1.- SISTEMA     <a name="mecanicas1"/>

Podemos dividir el juego en dos grandes fases:

**FASE DE PREPARACIÓN**

En primer lugar, se elegirá un circuito de forma aleatoria o importándolo. Esta decisión se hizo para que los jugadores pudiesen adaptar sus vehículos al circuito elegido.

Antes de iniciar una partida, los jugadores deberán escoger una nave. Hay disponibles cuatro naves: Júpiter, Neptuno, Marte y Saturno. Cada uno de estos vehículos representa uno de los cuatro elementos principales: aire, agua, fuego y tierra, respectivamente. Cada una de estas naves tendrá una serie de características distintas al resto, además de ciertas bonificaciones en ciertos aspectos relacionados con sus elementos. Estos aspectos serán explicados en apartados posteriores. 

Una vez escogida la nave pasaremos a elegir los signos del zodiaco, que aumentarán o disminuirán ciertas características de las naves, dándole un aspecto de estrategia y diferenciación con el resto de vehículos contrarios. Cada jugador podrá equipar a su nave hasta dos signos distintos. Cada signo aumentará una característica del coche y disminuirá otra. Además también pueden afectar a la probabilidad de ralentización en caso de existir módulos especiales en el circuito escogido. Esta decisión surgió para evitar signos del zodiaco muy poderosos, haciendo que el resto fueran ignorados. 

Los signos tienen su propio elemento, al igual que las naves, pero eso no implica que solamente los jugadores podrán equipar en sus naves los elementos compatibles. Cada jugador podrá elegir libremente sus dos signos a equipar.

A continuación, los jugadores personalizarán el reglaje de su vehículo, pudiendo elegir entre velocidad, aceleración o equilibrado o si la espaciodinámica afecta menos en curvas o en rectas.

**CARRERA**

Al iniciar una partida, los vehículos serán colocados en la línea de salida del circuito escogido. A continuación se mostrará una cuenta atrás, dando inicio a la carrera.

El vehículo se desplazará sobre el circuito de forma automática y el jugador podrá alterar su velocidad mediante una barra de desplazamiento vertical ubicada en la parte derecha de la pantalla. Para evitar una jugabilidad monótona haciendo que los jugadores se limiten a escoger la mayor velocidad posible se han incluido ciertas reglas típicas de la Fórmula 1. Por ejemplo, si un jugador lleva una velocidad muy elevada y se dirige a una curva sin bajar la velocidad, se saldrá del circuito, teniendo que reaparecer en un punto anterior y perdiendo un tiempo valioso.

Para ganar una carrera es necesario dar una serie de vueltas en total al circuito y llegar en primer lugar a la meta en la última vuelta. El número de vueltas es establecido por el creador del circuito y pueden ser cuatro, ocho, doce o dieciseis. Al dar una vuelta al circuito los jugadores serán desplazados al carril contiguo a su derecha, haciendo que los jugadores tengan que enfrentarse a las situaciones que presenten el resto de carriles. Además, si una nave consigue superar a otra en su propio carril será eliminada automáticamente.

En la interfaz de una partida se podrán observar el número de vueltas dadas al circuito en la zona superior de la pantalla, la posición de todos los jugadores en la esquina superior derecha junto a la velocidad actual de la nave. En la zona derecha de la pantalla se mostrará una barra desplazadora. Al mover el icono de esta podremos alterar la velocidad por fases.

En la esquina inferior izquierda se mostrará el botón de pausa. Esta pantalla nos mostrará los signos del zodiaco escogidos por cada nave y sus correspondientes reglajes. Desde esta pantalla podremos volver al circuito o salir de la partida.

Una vez finalizada la carrera se mostrará una pantalla con las posiciones de los jugadores, su mejor tiempo y los puntos obtenidos. Desde esta pantalla se podrá salir al menú principal.

**MODO LIGA**

En el modo Torneo se aplican las mismas reglas explicadas anteriormente pero, en lugar de correr una sola carrera, se competirá en cuatro circuitos distintos elegidos al azar. Una vez finalizada una carrera se mostrarán los resultados al igual que en una carrera normal, pero con diferencias. En este modo se incluye una puntuación, determinada por la posición obtenida en la carrera, la cual irá aumentando en las siguientes carreras y determinará al ganador del torneo. Esta puntuación se obtiene de esta forma:

* Primer puesto - 5 puntos.
* Segundo puesto - 3 puntos.
* Tercer puesto - 1 puntos.
* Cuarto puesto - 0 puntos.

Al finalizar las cuatro carreras se mostrará un ranking de los competidores.

**MI EQUIPO**

Al iniciar el modo "Mi equipo", se mostrará una lista con los circuitos que se correrán, siendo cuatro en total. A continuación, el jugador elegirá una nave al igual que en el modo normal. Una vez elegida se mostrará la interfaz del modo mánager.

En esta interfaz el jugador tendrá diferentes opciones disponibles:

- **Mi nave**: En esta sección los jugadores pueden gestionar los distintos aspectos de su nave, desde el zodiaco hasta los reglajes. En esta sección se añade una nueva sección llamada "Mejoras", la cual permite aplicar aumentos de características de forma limitada.
- **Simular**: Una vez el jugador haya alterado de forma eficaz su nave para el circuito, podrá simular una partida en el circuito elegido. Esta simulación no puede ser alterada por el jugador de ninguna forma. Una vez termine la simulación, se repartirán puntos de la misma forma que en el modo Torneo.

Al finalizar las cuatro carreras seleccionadas se declarará un ganador. Como puede apreciarse este es el modo más técnico y estratégico de Constela-Trix.

#### 5.1.2.- VEHÍCULOS  <a name="mecanicas2"/>

Las naves son los elementos fundamentales de Constela-Trix. A continuación se exponen las características principales, en qué consisten y la regla mnemotécnica utilizada:

- `VEL`: Velocidad de movimiento. Determina la velocidad máxima a la que puede llegar una nave.
- `ACEL`: Aceleración. Determina lo rápido que puede llegar una nave a máxima velocidad.
- `P`: Peso. Afecta a la velocidad y a la velocidad de frenado.
- `F`: Frenado. Determina lo rápido que tarda un coche en bajar de velocidad.
- `MARCHAS`: Relación de marchas. 
- `ED`: Espaciodinámica.

Las naves, su elemento y sus estadísticas son:

| **NOMBRE**      | **ELEMENTO**           | **VEL** | **ACEL** | **P**   | **F** |
| :-------------: | :--------------------: | :-----: | :------: | :-----: | :---: | 
| Júpiter         | Aire                   |   115   |   30     |   76.8  |   25  |   
| Neptuno         | Agua                   |   106   |   31.25  |   72    |   40  |  
| Marte           | Fuego                  |   97    |   40.5   |   48    |   22  | 
| Saturno         | Tierra                 |   160   |   27.5   |   55.2  |   70  |

#### 5.1.3.- SIGNOS DEL ZODIACO     <a name="mecanicas3"/>

Los signos del zodiaco forman una parte fundamental del juego, pudiendo aumentar o disminuir las características de cada coche dependiendo de la elección. En total existen doce signos del zodiaco y se dividen en los cuatro elementos: aire, agua, tierra y fuego, al igual que las naves.

Cada jugador podrá equipar a su nave dos signos a su elección, independientemente del elemento tanto del coche como el del signo elegido. Aun así, elegir elementos compatibles aportará ventajas extra, las cuales serán explicadas a continuación.

En la siguiente tabla se pueden ver todos los signos del zodiaco disponibleS y las características que varían:

| **SIGNO**    | **ELEMENTO**  | **VEL** | **ACEL** | **P** | **F** | **MARCHAS** | **ED** |
| :----------: | :-----------: | :-----: | :------: | :---: | :---: | :---------: | :----: |
| Aries        | Fuego         |    -    |          |   +   |       |             |        |
| Tauro        | Tierra        |         |          |   +   |       |      -      |        |
| Géminis      | Aire          |         |     -    |       |       |      +      |        |
| Cáncer       | Agua          |         |          |       |   -   |             |    +   |
| Leo          | Fuego         |         |     +    |       |       |             |    -   |
| Virgo        | Tierra        |    -    |          |       |   +   |             |        |
| Libra        | Aire          |    +    |          |   -   |       |             |        |
| Escorpio     | Agua          |         |          |   -   |       |      +      |        |
| Sagitario    | Fuego         |         |     +    |       |       |      -      |        |
| Capricornio  | Tierra        |         |          |       |   +   |             |    -   |
| Acuario      | Aire          |         |     -    |       |       |             |    +   |
| Piscis       | Agua          |    +    |          |       |   -   |             |        |

Además, al combinar los elementos de los signos con la nave se pueden obtener ciertas bonificaciones extras. Estas bonificaciones se activan al juntar dos o tres signos y/o naves del mismo elemento. Las bonificaciones son las siguientes:

- Fuego: Aumenta la aceleración.
- Tierra: Aumenta la velocidad.
- Aire: Se reduce la espaciodinámica.
- Agua: Se reduce el rozamiento de los módulos.

#### 5.1.4.- REGLAJES <a name="mecanicas4"/>

Hay dos tipos de reglajes: relación de marchas y espaciodinámica.
- **Relación de marchas**: Puede ser de velocidad (aumenta la velocidad), aceleración (aumenta la aceleración) o equilibrado. Esa modifica si marchas en cortas o en largas.
- **Espaciodinámica**: Funciona como la aerodinámica terrestre. Las naves tienen que ser capaces de superar unas ondas eléctricas. Puedes elegir si estas ondas te afecten menos en curvas o en rectas.

#### 5.1.5.- CIRCUITOS    <a name="mecanicas5"/>

Una de las principales características de Constela-Trix son sus circuitos y cómo crearlos. Cada circuito está dividido en módulos independientes, los cuales pueden ser conectados para formar un circuito completo. Al terminar un circuito se formará un camino el cual las naves recorrerán de forma automática. Existen varios tipos de módulos:

- Recta.
- Curva.
- *Loop*.
- Cambio de carril.
- Zigzag.

Además de estos módulos básicos existen cuatro módulos especiales que afectarán a la conducción de las naves. Cada módulo especial representa a uno de los cuatro elementos y pueden afectar al curso normal de una carrera, frenando las naves que no sean del mismo elemento durante un pequeño espacio de tiempo. Como se explicó anteriormente, estos efectos pueden ser contrarrestados por los signos del Zodiaco. A continuación se expone una comparación y cómo afectan las naves y signos.

- Si un jugador pasa por un módulo especial cuyo elemento no coincide con el de su nave y no tiene equipado ningún signo compatible, existe un **50%** de probabilidades de que el jugador sea frenado.
- Si un jugador pasa por un módulo especial cuyo elemento coincide con el de su nave y no tiene equipado ningún signo compatible, existe un **25%** de probabilidaddes de que el jugador sea frenado.
- Por cada signo del Zodiaco equipado compatible con el módulo especial la probabilidad de frenado se reduce en un **10%**.
- Si un jugador pasa por un módulo especiall cuyo elemento coincide con el de su nave y tiene equipados dos signos compatibles, la posibilidad de frenado se reduce a un **0%**.

Al ser una mecánica un tanto confusa se expondrá un ejemplo:

**Nave Neptuno (Agua) con los signo Cáncer (Agua) y Virgo (Tierra)**
- Módulo de aire: 50% de frenado (ni la nave ni los signos son del elemento aire).
- Módulo de agua: 15% de frenado (25% por nave de agua - 10% por signo de agua).
- Módulo de fuego: 50% de frenado (ni la nave ni los signos son del elemento fuego).
- Módulo de tierra: 40% de frenado (la nave no coincide, pero -10% por el signo de tierra).

#### 5.1.6.- CONSTRUCTOR    <a name="mecanicas6"/>

El juego ofrece a los usuarios un constructor de circuitos usando los módulos explicados anteriormente. Los jugadores podrán colocar, girar y unir cualquier módulo que deseen con total libertad, aunque existen un par de restricciones:

- Todos los circuitos deben estar unidos.
- Todos los circuitos deben tener un módulo de cambio de carril.

Al finalizar el diseño del circuito, el jugador deberá poner nombre al circuito creado, establecer el número de vueltas (cuatro, ocho, doce o dieciseis) y elegir el punto de salida. Una vez el autor considere que acabado su circuito, podrá subirlo a una base de datos general, dónde se almacenarán todos los circuitos creados por otros jugadores. Además, por cada circuito se creará un código para compartir el circuito creado con cualquier persona.

Los jugadores podrán descargar los circuitos de sus conocidos y amigos introduciendo el código correspondiente.

### 5.2.- ESTADOS JUEGO	<a name="estadosJuego"/>

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/ESTADOS%20DEL%20JUEGO.png)

Al iniciar una partida, el jugador tendrá que introducir su nombre.

**INICIO**: Menú que se muestra al iniciar el juego.<br>

- *JUGAR*: Empieza la partida.
- *EDITOR*: Accede al editor de circuitos.
- *TIENDA*: Se accede a la tienda, donde se muestran las skins disponibles, los módulos y la compra de moneda, además de nuestro saldo.
- *OPCIONES*: Permite cambiar el idioma entre español, inglés y gallego además de poder quitar el volumen.
- *CRÉDITOS*: Pantalla con información sobre los desarrolladores.

**MODOS DE JUEGO**: Este menú se muestra al pulsar el botón *JUGAR*. <br>

- *PARTIDA RÁPIDA*: En esta pantalla el jugador podrá correr una única carrera.
- *MODO LIGA*: Permite acceder al modo liga, en el que se correrán cuatro carreras elegidas de manera aleatoria.
- *TUTORIAL*: En este modo el jugador será guiado mediante mensajes por una partida rápida, para que el jugador aprenda los fundamentos del juego.

Las siguientes pantallas son comunes a los tres modos explicados anteriormente:

- *CIRCUITOS*: Se elegirá un circuito de forma aleatoria entre todos los disponibles en la base de datos o se podrá importar uno.
- *NAVES*: El jugador puede elegir una nave entre las cuatro disponibles.
- *ZODIACO*: Pantalla en la que se mostrarán los distintos signos del zodiaco. En esta pantalla se muestran los cambios que se aplican a cada vehículo.
- *REGLAJES*: El jugador puede adaptar el reglaje de su vehículo.
- *CARRERA*: Gameplay en tiempo real de la carrera. Hay un botón de *PAUSA*, el cual nos permite ver los signos del zodiaco del resto de competidores, además de su reglaje. Desde esta pantalla podremos salir al menú *INICIO*.
- *RESULTADOS*: En esta pantalla se muestran las posiciones de los jugadores, la mejor vuelta y los puntos obtenidos. Desde esta pantalla se puede volver al menú de *INICIO*. Si el jugador se encuentra en el *MODO LIGA*, avanzará a la siguiente carrera.

- *MI EQUIPO*: El jugador accederá a una lista de los circuitos que correrá en el modo mánager. Al avanzar de pantalla, el jugador podrá elegir una nave. A continuación, accederá a la pantala del *MODO MÁNAGER*. 

**MODO MÁNAGER**: <br>

- *SIMULAR*: Permite simular una partida con nuestra nave modificada. EL jugador no puede controlar la velocidad de la nave.
- *RESULTADOS*: Muestra los resultados de la partida.
- *MI NAVE*: En esta pantalla el jugador podrá cambiar ciertas características de su nave.

**MI NAVE**: <br>

- *MEJORAS*: Permite aplicar ciertos aumentos de características dependiendo de nuestras mejoras disponibles.
- *ZODIACO*: Pantalla en la que se mostrarán los distintos signos del zodiaco. En esta pantalla se muestran los cambios que se aplican a cada vehículo.
- *REGLAJES*: El jugador puede adaptar el reglaje de su vehículo.

**EDITOR DE CIRCUITOS**: En esta pantalla podemos empezar a formar nuestro circuito al pulsar *CREAR CIRCUITO*. <br>

- *CREAR CIRCUITO*: En esta pantalla podremos formar crear nuestros circuitos mediante los módulos, disponibles al pulsar el botón *MÓDULOS*. Además, en esta pantalla también podremos rotar los módulos seleccionados o borrarlos. Al considerar finalizado el circuito podremos crearlo pulsando el botón verde. A continuación el jugador le pondrá nombre al circuito, indicará el número de vueltas y elegirá el módulo de salida. Una vez terminado, el jugador podrá subir su circuito a la base de datos y obtendrá un código, el cual servirá para compartir el circuito con cualquier persona.

### 5.3.- INTERFACES	<a name="interfaces"/>

Todas las interfaces que se muestran están en español, pero también se puede jugar al juego tanto en inglés como en gallego.

`INICIO:`

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/capturasInterfaces/inicio.PNG)

`NOMBRE DE USUARIO:`

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/capturasInterfaces/nombreDeUsuario.PNG)

`MENÚ PRINCIPAL:`

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/capturasInterfaces/menuPrincipal.PNG)

`CRÉDITOS:`

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/capturasInterfaces/creditos.PNG)

`TIENDA:`

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/capturasInterfaces/tienda.PNG)

`CONFIGURACIÓN:`

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/capturasInterfaces/configuracion.PNG)

`MODOS DE JUEGO:`

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/capturasInterfaces/modosDeJuego.PNG)

`TUTORIAL:`

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/capturasInterfaces/tutorial.png)

`ELEGIR CIRCUITO:`

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/capturasInterfaces/elegirCircuito.PNG)

`ELEGIR NAVE:`

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/capturasInterfaces/elegirNave.PNG)

`ELEGIR SIGNOS:`

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/capturasInterfaces/elegirSignos.PNG)

`REGLAJES:`

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/capturasInterfaces/equilibrado.PNG)

`PARITDA RÁPIDA:`

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/capturasInterfaces/partidaRapida.PNG)

`MENÚ DE PAUSA:`

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/capturasInterfaces/menuDePausa.PNG)

`CLASIFICACIÓN:`

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/capturasInterfaces/clasificacion.PNG)

`EDITOR DE CIRCUITOS:`

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/capturasInterfaces/editorSeleccion.PNG)

`EDITOR:`

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/capturasInterfaces/editor.PNG)

`MODO MÁNAGER:`

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/capturasInterfaces/manager.PNG)

`PRESENTACIÓN MODO MÁNAGER:`

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/capturasInterfaces/presentacionManager.PNG)

`PARTIDA MODO MÁNAGER:`

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/capturasInterfaces/partidaManager.PNG)

### 5.4.- CONTROLES	<a name="controles"/>

Al poderse jugar en diferentes plataformas, se usan 2 sets de controles: PC y móvil. 

**CONTROLES PC**

Basado en ratón (Al utilizar controles sencillos tanto en los menús como en las carreras como tal no ha sido necesario utilizar controles de teclado).

*Controles Menú* <br>
`Ratón`: Seleccionar entre opciones<br>
`Click Izq Ratón`: Elegir opción

*Jugadores* <br>
`Click Izq Ratón en la barra de velocidad y arrastrar`: Aumenta o disminuye la velocidad del vehículo. Si el jugador arrastra la barra hacia la zona superior la nave irá aumentando de velocidad progresivamente hasta llegar al máximo disponible. Si el jugador arrastra la barra hacia la zona inferior de la pantalla la nave frenará progresivamente hasta quedar parada.

**CONTROLES MÓVIL Y TABLETA**

Basado en el control táctil. Los Menús se controlan con botones táctiles.

*Jugadores*<br>
`Pulsar y arrastrar barra de cambio de velocidad`: Al igual que en PC, al pulsar y arrastrar la barra de velocidad durante una partida podemos aumentar o disminuir la velocidad de nuestra nave.

*Botones Extra*<br>
`SALIR`: Sale al menú principal

### 5.5.- PROGRESO DEL JUEGO	<a name="progresoDelJuego"/>

El progreso del juego se verá reflejado de dos formas distintas: en las clasificaciones de cada partida y en las clasificaciones generales.

Al acabar cada carrera se mostrará una clasificación de esa carrera, indicando la posición en la que ha acabado cada jugador la carrera además del tiempo que han tardado en recorrer todas las vueltas del circuito.

### 5.6.- MODOS DE JUEGO	<a name="niveles"/>

En el juego se ofrecen tres modos de juego principales, dos de ellos siendo posible un modo multijugador entre dos y cuatro jugadores.

- **PARTIDA RÁPIDA**: El jugador elegirá su nave y sus signos del Zodiaco y competirá contra tres naves controladas por IA en un circuito escogido por el jugador. Al terminar la carrera escogida el jugador podrá salir al menú principal o volver a jugar.

- **MODO LIGA**: El jugador competirá en cuatro carreras consecutivas elegidas al azar contra tres naves controladas por inteligencia artificial. El ganador se determinará mediante un sistema de puntuación.

- **MI EQUIPO**: En este modo el jugador tendrá que ajustar los reglajes de su coche de forma que pueda recorrer un circuito sin percances.

## 6.- DISEÑO DEL MUNDO	<a name="diseñoDelMundo"/>
### 6.1.- PERSONAJES	<a name="personajes"/>

Podríamos considerar que los personajes del juego son las naves espaciales que escogen los jugadores para competir en las carreras. A continuación se muestran los bocetos de cada nave espacial:

- **Júpiter**:

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/Arte/Bocetos%20naves/Concept_Jupiter2.png)

- **Marte**:

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/Arte/Bocetos%20naves/Concept_Marte.png)

- **Saturno**:

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/Arte/Bocetos%20naves/Concept_Saturno3.png)

- **Neptuno**:

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/Arte/Bocetos%20naves/Concept_Neptuno2.png)

### 6.2.- LOCALIZACIONES	<a name="localizaciones"/>

Este apartado se refiere a los diferentes escenarios visuales en los que se desarrolla el juego. Al no tener un escenario fijo, sino que este depende del circuito elegido, en este apartado se expone un ejemplo de circuito. Al ser un juego relacionado con naves espaciales, todas las localizaciones se ubican en el espacio exterior.

* **Circuito de ejemplo**:

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/Arte/BocetosPista/ejemplo%20circuito.png)

---

## 7.- ARTE	<a name="arte"/>
### 7.1.- ESTILO Y REFERENCIAS<a name="estiloYReferencias"/>	

Al ser un juego dirigido a todo los públicos, pero especialmente al público adolescente, se ha querido optar por unos diseños vistosos y atractivos. Debido a que las naves tienen los nombres de algunos dioses romanos se añadieron en su diseño final ciertas referencias dependiendo del dios. A continuación se exponen cómo han afectado estas referencias mitológicas a cada una de las naves:

- **Júpiter**:

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/REFERENCIAS%20MITOL%C3%93GICAS/jupiterDios.jpg)

El dios Júpiter es el equivalente al dios griego Zeus. Uno de sus principales símbolos es el rayo y es por ese motivo que la nave Júpiter tiene un cierto parecido a una pistola eléctrica.

- **Marte**:

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/REFERENCIAS%20MITOL%C3%93GICAS/marteDios.jpg)

Marte es conocido como el dios de la guerra y normalmente es representado con armadura, espada, escudo y caso. En este caso, la nave Marte representa un casco.

- **Saturno**:

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/REFERENCIAS%20MITOL%C3%93GICAS/saturnoDios.jpg)

Saturno es el dios de la agricultura y la cosecha y normalmente era representado con una hoz. La nave Saturno tiene forma de hoz.

- **Neptuno**: 

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/REFERENCIAS%20MITOL%C3%93GICAS/neptunoDios.jpg)

Neptuno es el dios de los mares y los océanos y normalmente era representado con un carro de combate y con un tridente. Su respectiva nave representa el tridente de Neptuno.

### 7.2.- ARTE FINAL	<a name="arteFinal"/>

- **Júpiter**:

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/Arte/NavesFinalesPNG/JupiterFinalPNG.png)

- **Marte**:

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/Arte/NavesFinalesPNG/MarteFinalPNG.png)

- **Saturno**:

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/Arte/NavesFinalesPNG/SaturnoFinalPNG.png)

- **Neptuno**:

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/Arte/NavesFinalesPNG/NeptunoFinalPNG.png)

A continuación mostramos una imagen con los modelos 3D de las cuatro naves disponibles en el juego:

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/Arte/RedesSociales/ImagenModelos3D.png)

### 7.3.- ARTE PROMOCIONAL	<a name="artePromocional"/>

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/Arte/RedesSociales/Teaser.png)

---

## 8.- SONIDO	<a name="sonido"/>

Al tratarse de un juego de carreras se decidió utilizar música electrónica y EDM, que animase al jugador a jugar y a mantenerse en tensión durante toda la competición. Además, el juego transcurre en el espacio exterior, por lo que este tipo de música encajaba perfectamente con la estética general que se quería conseguir. Por otro lado, la música utilizada para el constructor de circuitos es calmada y permite al jugador concentrarse en la tarea. 

### 8.1.- BANDA SONORA	<a name="bandaSonora"/>

Todos los temas de la banda sonora son assets externos. Todas las canciones han sido obtenidas de Free Stock Music, una página web que ofrece temas musicales y efectos sonoros con licencia Creative Commons.

<a href="https://www.free-stock-music.com/"/>Free Stock Music</a>

A continuación se exponen los temas utilizados para el videojuego junto al nombre de la pieza y su correspondiente autor:

- *Tema Menú*: Sixty Four Years by Electronic Senses<br>

Sixty Four Years by Electronic Senses | https://soundcloud.com/electronicsenses
Music promoted by https://www.free-stock-music.com
Creative Commons Attribution-ShareAlike 3.0 Unported
https://creativecommons.org/licenses/by-sa/3.0/deed.en_US

- *Tema Carrera*: Banger by FSM Team feat. < e s c p ><br>

Banger by | e s c p | https://escp-music.bandcamp.com
Music promoted by https://www.free-stock-music.com
Attribution 4.0 International (CC BY 4.0)
https://creativecommons.org/licenses/by/4.0/

- *Tema Constructor*: Lucid Dreaming by FSM Team feat. < e s c p><br>

Lucid Dreaming by | e s c p | https://escp-music.bandcamp.com
Music promoted by https://www.free-stock-music.com
Attribution 4.0 International (CC BY 4.0)
https://creativecommons.org/licenses/by/4.0/

### 8.2.- EFECTOS DE SONIDO	<a name="efectosDeSonido"/>

Los efectos sonoros han sido obtenidos de Mixkit, una página web que ofrece recursos de "stock" de manera gratuita, desde música y efectos sonoros hasta vídeos y fotos. Estos efectos sonoros pueden ser utilizados para videojuegos, tal y como expone la licencia de Mixkit para efectos de sonido:

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/Licencias%20m%C3%BAsica/efectosSonorosLicencia.PNG)

<a href="https://mixkit.co/"/>Mixkit</a>

- Long sweeping air swoosh.
- Sci Fi positive notification.
- Sci Fi error alert.
- Sci Fi click.
- Fast sweeping transition.
- Short race countdown.

---

## 9.- NARRATIVA Y GUION	<a name="narrativaYGuion"/>
### 9.1.- SINOPSIS <a name="sinopsis"/>	

Una vez al año, en cierto lugar de la galaxia, se celebra Constela-Trix, una gran competición de carreras de naves espaciales. Pilotos de todas partes de la galaxia se reúnen en este lugar para dar lo mejor de sí y conseguir ganar el torneo. Pero esta ocasión es más especial que cualquier otra, ya que se inaugura el gran constructor de circutios, que permitirá a los espectadores diseñar el circuito por el que correrán los pilotos.

La competición cuenta con unos participantes bastante estrafalarios como, por ejemplo, Lancelot, un ricachón procedente de Saturno que siempre lleva el coche más rápido, pero sus habilidades al volante dejan mucho que desear. Otra participante muy interesante es Vagalume, procedente de Marte, gran fan de la Fórmula 1 terrestre y primeriza en las carreras espaciales. Por otro lado tenemos a la capitana A'Rhea, una piloto experimentada en las fuerzas atmosféricas de Júpiter y con ganas de ganar para apoyar a su familia. Y toda esta gran competición no podría ser posible sin Uisge, CEO de Ataraxia S.A. y patrocinador del equipo oficial de Neptuno. ¿Quién llegará a lo más alto en esta nueva temporada de Constela-Trix?

---

## 10.- DETALLES DE PRODUCCIÓN	<a name="detallesDeProduccion"/>
### 10.1.- MIEMBROS DEL EQUIPO	<a name="miembrosDelEquipo"/>
<img src="https://github.com/AtaraxiaDevs/breakfast/blob/main/GDD/LogoAtaraxia/logo_definitivo.png" width="50px"> **Daniel Ayllón Peinado**: Programador, Scrum Master y CM.<br>
<img src="https://github.com/AtaraxiaDevs/breakfast/blob/main/GDD/Iconos%20Desarrollador/Pablo.jpg" width="50px"> **Pablo García Sánchez**: Artista y Diseñador 2D <br>
<img src="https://raw.githubusercontent.com/AtaraxiaDevs/breakfast/main/GDD/Iconos%20Desarrollador/Celtia.png" width="50px"> **Celtia Martin García**: Artista 2D y Programadora.<br> 
<img src="https://github.com/AtaraxiaDevs/breakfast/blob/main/GDD/Iconos%20Desarrollador/Dani.jpeg" width="50px"> **Daniel Muñoz Rivera**: Game Designer y Usabilidad.<br>
<img src="https://github.com/AtaraxiaDevs/breakfast/blob/main/GDD/LogoAtaraxia/logo_definitivo.png" width="50px"> **Alberto Sánchez Mateo**: Product Owner, Programador y Web Designer. <br>
<img src="https://raw.githubusercontent.com/AtaraxiaDevs/breakfast/main/GDD/Iconos%20Desarrollador/Wei.png" width="50px"> **Wei Zheng**: Artista técnico y Diseñador 2D. <br>

### 10.2.- CICLO DE VIDA	<a name="cicloDeVida"/>

La intención del equipo de desarrollo es alargar la vida del juego lo máximo posible y crear una comunidad rica y llena de jugadores. Para conseguir este objetivo, hemos definido un ciclo de vida de los dos primeros años del videojuego dividida en seis fases.

En la primera fase lanzaremos una beta abierta del juego, la cual servirá como primera toma de contacto con los jugadores. Además, uno de nuestros principales objetivos en esta fase es solucionar los posibles errores que hayan surgido durante el desarrollo del videojuego. Gracias al lanzamiento del videojuego en forma de beta abierta podremos "testear" el videojuego a una mayor escala gracias a los jugadores, lo que nos permitirá encontrar y solucionar errores lo antes posible. Estimamos que esta fase tendrá una duración aproximada de dos meses.

En la segunda etapa el juego abandonará la fase de beta abierta, produciéndose el lanzamiento ofical del juego. Lo ideal sería tener solucionados la mayoría de errores solucionados antes del lanzamiento oficial, pero no descartamos que sigan apareciendo errores, por lo que revisaremos el juego cada poco tiempo para solucionarlos lo antes posible. No solo pensamos solucionar errores, sino que además incluiremos nuevos módulos de circuitos de forma gratuita como, por ejemplo, un módulo curva inclinada. Al aumentar el número de jugadores necesitaremos ampliar el tamaño de la base de datos de circuitos ya que, al aumentar el número de jugadores, la cantidad de circuitos generados aumentará exponencialmente, pudiendo llegar a colapsar la base de datos disponible, impidiendo que los jugadores puedan subir a la nube sus creaciones. Por último, uno de los grandes objetivos de esta fase es la inclusión del modo multijugador online, algo que se nos ha quedado en el tintero y que consideramos fundamental para la correcta realización del resto de etapas. Estimamos que esta etapa, debido a su gran complicación técnica, tenga una duración aproximada de cuatro meses.

Como se ha mencionado anteriormente, uno de los principales objetivos que queremos conseguir con este proyecto es conseguir una comunidad de jugadores activa. Para conseguir esto, pensamos introducir el primer evento online de Constela-Trix, donde celebraremos un torneo entre los jugadores más activos de la comunidad y presentaremos novedades jugables de peso, como la ampliación del modo mánager con nuevas opciones. Es por este motivo que la inclusión del multijugador online en la segunda etapa es de vital importancia. Por último, mostraremos una cinemática animada mostrando los origenes de la Capitana A'Rhea, uno de los personajes del juego. De esta forma podremos expandir la historia del juego, ampliando el *lore* contado mediante las cuentas de Twitter de los personajes.

Otro de los grandes objetivos de la tercera fase es introducir un modelo de donaciones mediante el uso de Patreon. Decidimos utilizar este método ya que es el que mejor se adapta al modelo de negocio que queremos crear con Constela-Trix, el cual será explicado en su correspondiente sección. Esta fase tendrá una duración aproximada de cuatro meses.

En la cuarta etapa celebraremos el primer aniversario del juego con más novedades de peso. En primer lugar organizaremos un segundo evento online. Al igual que en el primer evento, se celebrarán varios torneos competitivos para todos los jugadores que quieran participar. Se mostrará otra cinemática animada sobre el origen de Uisge, otro de los personajes de Twitter. Como se ha dicho anteriormente, en este evento online se mostrará una nueva característica del juego: la personalización completa del vehículo, exclusiva del modo mánager. El jugador podrá modificar casi cualquier aspecto físico de su nave, desde los propulsores a los alerones. Además, el modo mánager será ampliado de nuevo con un modo durabilidad, en el que los jugadores tendrán que cambiar de coche cada cierto tiempo para evitar quedarse tirado en la carretera. Pensamos que estas dos nuevas adiciones fomentarán la parte estratégica del título. También anunciaremos un evento del primer aniversario del juego, con torneos oficiales todas las semanas y otras novedades. Por último se entregarán una serie de premios por categorías: más circuitos creados, mejor jugador, mejor personalización, etc. Al ser una fase con tanto contenido técnico y con una gran carga de organización, estimamos que dure aproximadamente medio año.

La quinta etapa estará centrada principalmente en el merchandising. Estos productos consistirán principalmente en figuras de las cuatro naves principales y un primer cómic que explorará la creación de Constela-Trix como competición de naves espaciales, aumentando todavía más el *lore* del universo creado. Por último se crearán skins especiales para las naves en una colaboración con nuestro anterior juego, Break-Troops-Fast (BTF para acortar). En este juego, unos alienígenas invaden ciertos alimentos del desayuno, como magdalenas o zumos, para convertirlos en vehículos con los que pelear entre sí. Estas skins convertirán las naves espaciales en comida y en la cabina de mandos se mostrará a un alienígena de BTF. Esta fase tendrá una duración aproximada de dos meses.

Por último, en la sexta etapa se celebrará el evento online del segundo aniversario del juego. Al igual que en el evento anteriormente descrito, se celebrarán distintos torneos y se repartirán distintos premios a la comunidad por el apoyo proporcionado. En este evento se anunciará un nuevo cómic y se mostrará la tercera cinemática animada, con Vagalume como protagonista. Durante esta fase anunciaremos una transición a las principales tiendas digitales de PC (Epic Games Store y Steam), además de a Google Play Store y a la App Store de Apple. El título será lanzado como un *free-to-play* con compras dentro de la aplicación. Esta fase tendrá una duración aproximada de seis meses.

Una vez cumplidas las seis fases iniciales del proyecto pensamos ampliar el juego con nuevas funciones, seguir haciendo torneos online o presenciales si la situación lo permitey y arreglando distintos errores pero, al ser a tan largo plazo, no tenemos una planificación exacta establecida.

### 10.3.- MODELO DE NEGOCIO <a name="modeloDeNegocio"/>

*MODELO DE NEGOCIO*

El modelo de negocio principal va a ser *pay what you can* (PWYC). En este modelo cada jugador decide pagar lo que considere justo por nuestro producto. En un principio, el juego es totalmente gratuito, pero presenta una serie de añadidos opcionales, como skins para las naves o módulos nuevos a un precio reducido. El equipo de desarrollo decidió utilizar este modelo de negocio ya que, en una encuesta interna entre conocidos y amigos de los desarrolladores, nadie estaba dispuesto a pagar dinero por un juego de navegador.

En un principio vamos a ofrecer la compra de una moneda virtual creada en exclusiva para el juego, la Ataraxia Coin (AC). Esta moneda solamente se podrá conseguir mediante dinero real y se venderá en paquetes:
 - 50 AC a 0,99 €.
 - 150 AC a 1,99 €.
 - 300 AC a 2,99 €.
 - 500 AC a 3,99 €.
 - 1000 AC a 4,99 €.
 - 1500 AC a 5,99 €.

Con estas monedas el jugador podrá comprar skins para las naves, nuevos módulos para la creación de circuitos, etc. Además, también planeamos expansiones de contenido con elementos del zodiaco de otras culturas, como el zodiaco maya o chino. A continuación mostramos una lista con algunos precios orientativos.
- Expansión Zodiaco - Ofiuco (200 monedas): Ofrece un nuevo signo del zodiaco único con sus propias características.
- Pack curvas (150 monedas): Nuevos módulos para los circuitos.
- Materiales exclusivos (50 monedas): Se ofrecerán nuevos materiales para módulos como, por ejemplo, hielo o fuego.
- Skins (50 monedas): Permite cambiar el aspecto de la nave.

Además, también podremos vender los archivos .stl para que los usuarios puedan imprimir sus propias naves. Por último, el elemento más interesante sería un editor de módulos, donde los jugadores podrán crear sus propios módulos para poder usarlos en cualquier circuito.

El principal objetivo que queremos conseguir es la fidelización de los usuarios. Creando un mundo rico mediante cinemáticas, cómics o las propias cuentas de Twitter, podemos enganchar a los jugadores a la historia que estamos creando. No solo esto, sino que los propios usuarios podrán introducir a conocidos y amistades a nuestro juego gracias al editor de circuitos.

También consideramos la creación de un nuevo juego en forma de *spin-off* de Constela-Trix, utilizando el mismo universo ya creado y ampliando la historia presentada todavía más. Al contrario que Constela-Trix, este juego no sería *free-to-play*, sino que saldría al mercado a un precio todavía por concretar.

Otra opción que barajamos será la creación de merchandising para el juego. Como ya se ha explicado anteriormente, podríamos vender los archivos .stl de las naves espaciales para poder ser utilizados en impresoras 3D, pero este aparato no es algo que esté disponible para todos los bolsillos. De esta forma, vamos a lanzar una serie de figuras oficiales como principal forma de merchandising. Existen más alternativas, como la creación de cómics sobre los distintos acontecimientos y personajes de nuestro universo ficticio e incluso la creación de un juego de mesa emulando el juego de navegador.

Por último, implementaremos un sistema de donaciones basado en Patreon. Hemos decidido utilizar esta herramienta debido a que es la que mejor se adapta a nuestros dos pilares fundamentales del modelo de negocio: PWYC y fidelización. Patreon permite establecer una serie de niveles dependiendo del dinero aportado. Por cada nivel los desarrolladores ofrecen una serie de recompensas y por cada nivel superior se dan recompensas más interesantes y valiosas. El equipo ha decidido establecer los siguientes niveles o *tiers*:
- *Tier* 1: Los jugadores recibirán un boletín de noticias mensual y una invitación a un servidor de Discord donde podrán hablar del juego y charlar con los desarrolladores y el resto de suscriptores. Valor aproximado de 1 €.
- *Tier* 2: Los jugadores recibirán un conjunto de skins exclusivas de Patreon + todos los beneficios de *tier* 1. Valor aproximado de 3 €.
- *Tier* 3: Los jugadores recibirán un conjunto de módulos exclusivas de Patreon + todos los beneficios de *tier* 1. Valor aproximado de 5 €.
- *Tier* 4: Los jugadores recibirán los beneficios de todas las *tiers* anteriores. Valor aproximado de 7 €.
- *Tier* 5: Los jugadores podrán diseñar en exclusiva una skin para el juego + todos los beneficios de *tiers* anteriores. Valor aproximado de 12 €.

*MONETIZACION*

- *Free-to-play*: No existe ningún coste a la hora de jugar. El juego se ofrece de forma completa gratuitamente.
- Ataraxia-Coins: Principal forma de monetización. Sirve para comprar elementos cosméticos y módulos.
- Merchandising: Venta de merchandising como figuritas, cómics o juegos de mesa basados en la marca.
- *Spin-off*: Nuevo juego basado en el mismo universo que Constela-Trix, pero a precio completo.
- Patreon: Modelo de negocio basado en donaciones. Ofreceremos distintas recompensas a los jugadores dependiendo de cuánto aporten a la compañía.

*PÚBLICO META*

El principal objetivo de nuestro modelo de negocio es atraer el mayor número de personas para que prueben nuestro juego. Como dependemos del "boca a boca" entre amigos y compañeros, además del uso de las redes sociales, nuestro principal público meta son los jóvenes adultos, ya que muchos de estos pueden acceder a sus propios recursos financieros y abundan en las redes sociales.

Pero no nos quedamos aquí. También podemos atraer a jóvenes gracias a nuestro merchandising, especialmente con las figuritas de las naves y los cómics. Por último, también queremos atraer a los fans de la Fórmula 1 gracias a nuestro modo mánager. Este modo permite planificar y seguir una carrera como si fuera una de verdad, lo cual puede interesar a estos forofos.

*MODELO DE LIENZO*

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/canvasModelbusiness.png)

### 10.3.- MARKETING <a name="modeloDeNegocio"/>

- Promoción en redes sociales: El juego se promociona principlamente a través de la cuenta de Twitter @AtaraxiaDevs. En esta cuenta se han publicado periódicamente distintas actualizaciones sobre el juego, desde concept art hasta interfaces y modelos finales. También ha promocionado los distintos vídeos que se subían al canal de YouTube de la organización.
- *Roleplay* en Twitter: Además de la cuenta principal, se han creado otras cuatro cuentas simulando ser personajes del juego. Cada uno de estos personajes apoya a cada una de las naves disponibles en el juego: Saturno, Neptuno, Júpiter y Marte. Hemos interaccionado con los tweets de la cuenta principal, entre nosotros y con el resto de cuentas de clase. Por último, hemos intentado simular una narrativa mediante estas cuentas, algo pocas veces visto, lo cual ha hecho a estas cuentas tremendamente valiosas.
- YouTube: En el canal de YouTube de la empresa, AtaraxiaDevs, hemos ido publicando cada cierto tiempo unos vídeos enseñando los modelos de las naves del juego, además del trailer del juego. Gracias a la cuenta de Twitter hemos podido promocionar estos vídeos, aumentando sus visitas.
- Portfolio: Gracias al porfolio hemos podido promocionarnos como una empresa de videojuegos al más alto nivel. Hemos aprovechado esta página web para que los interesados puedan conocer y contactar con los distintos miembros del equipo. Además, también promocionamos nuestro anterior proyecto, Break-Troops-Fast.
- Blog: Dentro del portfolio existe una sección de blog, donde publicamos distintas entrevistas a los diferentes miembros del equipo explicando su trabajo dentro de cada proyecto.

---

## 11.- POST MORTEM	<a name="postMortem"/>
### 11.1.- RETROSPECTIVA PERSONAL <a name="retroPersonal"/>
#### 11.1.1.- DANIEL AYLLÓN PEINADO <a name="danielAyllonPeinado"/>

Mi rol con respecto al anterior proyecto cambió a petición propia, ya que yo no controlaba Unity tanto como otros miembros del equipo, por lo que intercambiamos roles Daniel Muñoz y yo, pasando a escribir el GDD, el diseño del juego y manteniendo las redes sociales.

Hablando de mi parte, el manejo de redes sociales ha mejorado bastante con respecto al anterior proyecto. Mientras que en el primer proyecto la cuenta de Twitter no llegaba casi a los 20 tweets he conseguido superar la barrera de los 100 tweets entre promociones, RTs y respuestas a otros equipos de clase. Además, la creación de nuevas cuentas de Twitter y la “narrativa mediante RRSS” que hemos creado ha sido súper satisfactoria y muy divertida de manejar.  

En cuanto a los otros apartados tengo que admitir que ha habido varios errores por mi parte. Bajo mi opinión, diría que no es para nada un mal documento, pero sí que es cierto que he tenido que estar haciéndolo hasta el último momento debido a falta de tiempo. Este también es el motivo por el que al final no he podido componer la música para el juego, teniendo que volver a utilizar canciones y efectos de sonido con licencia CC. En mi defensa para la música diré que en mi vida he compuesto ningún tipo de canción ni efecto, así que cuando pude investigar cómo componer y qué programas utilizar, ya era demasiado tarde. 

En general, estoy muy satisfecho con el trabajo realizado por el resto del equipo. Ha salido un proyecto mucho más potente a nivel empresarial que el anterior, aunque me hubiese gustado tener multijugador online. 

#### 11.1.2.- PABLO GARCÍA SÁNCHEZ <a name="pabloGarciaSanchez"/>

Mi trabajo personal consistía en el diseño de interfaces, fondos y diseño y modelado de pistas para los circuitos. Por mi parte, me siento satisfecho con los resultados obtenidos. En la parte de interfaces, me ha gustado mucho trabajar con este estilo espacial del juego y crear todos los elementos que contienen me ha resultado cómodo. Respecto a la parte de circuitos, me costó más puesto que tuve que echar horas para recordar todas las herramientas de los programas utilizados para modelar. Además, los resultados obtenidos, pese a ser buenos, podrían haber sido óptimos y haber facilitado al equipo de programación su implementación en Unity. 

En el trabajo grupal, se nos ha dado mejor que el primer proyecto puesto que mejoramos en organización y reparto de tareas. Además, todos los miembros del equipo se han implicado al máximo. Ha sido fácil entenderse y comunicarse entre los departamentos de redes sociales, arte y programación. 

#### 11.1.3.- CELTIA MARTÍN GARCÍA <a name="celtiaMartinGarcia"/>

Para empezar, decir que me siento orgullosa de mi trabajo y que siento que he crecido como programadora. He tenido mis fallos como es obvio, pero he aprendido mucho. Además, que antes me sentía incapaz de crear un proyecto de tal tamaño, y ahora me siento más confiada. 

Sin embargo, he tenido bastantes fallos, el trabajo en grupo en cuanto a programación se me da algo mal y he tenido diferencias con otros programadores (como Dani Muñoz, lo siento Dani), pero hemos sabido salir de las reyertas y siento que en ese aspecto este trabajo también me ha ayudado a mejorar este aspecto. También peco de desordenada en el código, y de “síndrome de Diógenes Digital” (mucho código ya no válido comentado por si las moscas), y a falta de tiempo para organizar, el código ha quedado un poco caótico. También añadir que se ha primado la funcionalidad ante el rendimiento, lo cual podría ser un punto importante a mejorar. 
 
Como equipo, hemos trabajado bien, con buena comunicación, y todos son muy buenos con lo suyo y se nota que lo hemos hecho con cariño, y creemos que ha quedado un producto interesante. 
 
Como puntos a mejorar, es cierto que hemos tenido poco tiempo para trabajar, y que algunas cosas podrían haberse hecho con más tiempo de antelación y con más atención. Además, el diseño del juego tardó algo en concretarse, lo cual resultó en descoordinación y funcionalidades añadidas sobre la marcha. 
 
#### 11.1.4.- DANIEL MUÑOZ RIVERA <a name="danielMunozRivera"/>
 
Yo he sido el encargado de hacer la lógica del juego, los estados del juego, la implementación de interfaces y traducción, y la programación de distintos apartados a lo largo del juego. En el anterior, me encargué del GDD y el diseño de juego, cambiando de rol con mi compañero Daniel Ayllón. 
 
Mi trabajo personal creo que ha sido bueno, he apoyado todo el rato a la programadora principal, que ha sido Celtia, en todo lo que ha necesitado. Las interfaces y transiciones han quedado muy bien, y el traductor funciona perfectamente. He aprendido mucho, tanto de cosas que ya sabía cómo de cosas que no, y sin duda Alberto y Celtia me han ayudado muchísimo. Tengo que mejorar en entender más rápidamente el código de mis compañeros, ya que tardo mucho en pillar todo y me cuesta un poco adaptarme. Para no ser mi rol habitual, ha estado muy bien. 
 
En cuanto al trabajo en grupo, ha salido bastante bien. El nuevo sistema de dailys ha servido para irnos enterando de nuestros progresos, y saber cómo íbamos en todo momento. Los distintos apartados han brillado en su campo y todo ha cohesionado muy bien. El único problema flagrante, y está mal que yo lo diga, ha sido el GDD. La primera versión ha llegado muy tarde, con el juego casi acabado, y ha habido algunos problemas de coordinación por la falta del mismo. Eso se ha notado en la comunicación del equipo. Otro problema, que es mucho menor, es intentar el multijugador. Hemos sido demasiado ambiciosos en ese aspecto. 
 
En conclusión, muy buen trabajo. Supera con creces el anterior proyecto, y el juego esta vez sí responde a todo el esfuerzo que hemos metido.  
 
#### 11.1.5.- ALBERTO SÁNCHEZ MATEO <a name="albertoSanchezMateo"/>
 
En cuanto a mi trabajo personal, me frustra el no haber conseguido implementar el multijugador a tiempo. Era algo muy ambicioso el entender una librería nueva y tan complicada como Photon desde 0. Sin embargo, a pesar de no mover tarjetas como es debido, la gestión de las reuniones y la información en importante en el Trello ha sido en mi opinión. También me siento orgulloso de haber llevado a cabo la idea de códigos servidos por una base de datos, lo cual hace de nuestro proyecto algo interesante y diferente, basándonos en la comunidad que buscamos. 

En cuanto al trabajo del grupo, mis compañeros son una maravilla de personas: comprenden las situaciones especiales, apoyan y dan soluciones a los problemas que puedan surgir y colaboran en todo momento. Sin embargo, al igual que yo, no son capaces de mover las tarjetas de Trello. 

#### 11.1.6.- WEI ZHENG <a name="weiZheng"/>

Por mi parte, he quedado satisfecho con los concepts realizados además del modelado final de las naves. También el grabar los vídeos para las redes sociales y sobre todo el realizar muchas variaciones de las naves como colores, formas, etc., para poder mostrar distintas opciones a elegir, y seguir las opiniones y decisiones del grupo. Por otra parte, al no tener mucha experiencia con el modelado 3D, no he ido tan rápido como habría querido. 

Por la parte grupal, hemos trabajado muy bien en equipo ya que nos hemos organizado mejor que en la primera práctica, además de que ha habido mayor comunicación. Gracias a esto, todos hemos podido aportar nuestras ideas y opiniones, resultando en una mayor implicación en el juego.  

### 11.2.- RETROSPECTIVA GRUPAL <a name="retroGrupal"/>
#### 11.2.1.- PUNTOS FUERTES <a name="puntosFuertes"/>

- **Comunicación**: a diferencia del proyecto anterior, al haber hecho 2 ‘dailys' a la semana, ha ayudado a forzarnos a expresar qué tareas estaban siendo atendidas en ese momento y qué nos preocupaba para terminar. Además, el uso del Trello como centro neurálgico de cada reunión, nos ha hecho priorizar y avanzar muy rápido, llegando a tal punto de ser capaces de gestionar todas las dudas en reuniones de 1 hora. 

- **Producto diferencial**: si algo hemos conseguido, es superarnos en cuanto al producto que hemos creado. Hemos logrado terminar un juego enfocado a las características de la plataforma que estamos usando: compartir contenido en la web a través de los códigos de circuito. Además, la personalización de la experiencia de usuario, así como la creación de circuitos son partes de las que nos sentimos orgullosos como grupo. 

- **Buena cohesión**: tanto las ideas, como las decisiones se toman teniendo en cuenta todos los puntos de vista. Hemos conseguido crear en poco tiempo un ambiente “chachi” donde no nos da vergüenza el decir lo que pensamos en todo momento. 

- **Aprendizaje**: hemos sido capaces de adaptarnos muy rápidamente al nuevo sistema, mejorando mucho la calidad de nuestras funciones respectivas. Si tuviésemos un mes más, no cabría duda de que el juego saldría todavía más pulido, ya que conseguimos cada día encontrar maneras de mejorar. 

#### 11.2.2.- PUNTOS DÉBILES <a name="puntosDebiles"/>

- **Ambición**: en este proyecto quizás hemos pecado de demasiado ambiciosos en ciertos aspectos: el modo multijugador y la composición de música original a pesar de haberlo intentado no han salido adelante. Sin embargo, hemos sabido reaccionar a tiempo, haciendo que este fallo de organización no haya supuesto una carga para otros aspectos del juego. 

- **Trello**: a pesar de definir muy bien cada sprint los objetivos que queríamos cumplir, muchos de nosotros no hemos sido capaces de utilizar la herramienta de manera óptima: no creábamos tareas, no se movían del todo o en algunos casos ni se realizaban. A pesar de ello, gracias a las “dailys” constantes, hemos sabido organizarnos sin comprometer el resultado final. 

- **Falta de tiempo**: debido a factores ajenos a los integrantes del grupo, este proyecto ha sido un trabajo titánico al hacerse en el mes de diciembre con otros proyectos y las navidades en medio. Muchas de las tareas se han retrasado por esto. 

### 11.3.- EXTERNOS <a name="externos"/>
#### 11.3.1.- USUARIO CASUAL <a name="usuarioCasual"/>

Perfil de estudiante universitario que juega a muchos juegos de móvil en su día a día.

En cuanto a los controles del juego le han parecido complicados de entender de primeras: se salía mucho del circuito por no controlar la velocidad de la nave. Además, al no ser usuario experto no ha sabido cual era la mejor configuración para el circuito que se le presentaba. En el modo “Mi Equipo”, ha tenido las mismas dificultades debido a la configuración de la nave. En cuanto al editor, le ha parecido fácil de usar, aunque a veces tuviese errores en los que no se conectaban los módulos del todo bien. 

### 11.4.- ¿HEMOS MEJORADO? <a name="hemosMejorado"/>

En este apartado, recogeremos los puntos que recogimos en el posmortem anterior donde dedicamos un apartado a las soluciones que intentaríamos implementar para este proyecto y analizaremos si han sido fructíferas o no: 

- **Priorización y organización**: creemos que hemos mejorado, la implementación de un workflow concreto en las reuniones, establecer una serie de metas en cada sprint y el apoyarnos todavía más en la buena comunicación que ya teníamos ha hecho que mejoremos en este apartado. Incluso cosas que no han salido adelante como el multijugador, consideramos que ha sido una buena decisión, ya que hemos priorizado otros aspectos del juego que eran mucho más necesarios para mostrar un primer prototipo del juego. 

- **Estimación**: a pesar de nuestra falta de experiencia como desarrolladores, este proyecto ha tenido una mejor estimación de las tareas. La mayoría de los objetivos que hemos planteado para cada sprint han sido completados con éxito, permitiéndonos ir bastante siempre con bastante tiempo para solucionar imprevistos. 

- **Testeo**: en esta práctica sí que hemos sido capaces de reservar tiempo para testear cada funcionalidad que hemos ido añadiendo. Es por eso que nos sentimos mucho más seguros de la jugabilidad de este juego. 

- **Workflow de las reuniones**: como hemos mencionado en apartados anteriores, este ha sido el posible highlight de este proyecto en cuanto a grupo se refiere. Hemos mejorado mucho gracias a estas reuniones, forzándonos a decir y escuchar que hacen nuestros compañeros y qué es lo que les preocupa. Además, hemos dado en el clavo, ya que a medida que iba pasando el tiempo estas reuniones se hacían más eficientes y aunque hubiese más puntos de los que hablar, terminábamos mucho antes. 

- **Mejora de las redes sociales**: ha habido una mayor cadencia de tweets y de contenido en la cuenta de empresa, pasando de los 20 tweets en el proyecto anterior a 80 en un solo mes. Además, también hemos logrado el interactuar más con las cuentas de los otros grupos, dándonos un poco más a conocer y consiguiendo establecer buenas relaciones con ellos. Además, hemos introducido las cuentas de los personajes, donde pretendíamos expandir el mundo del juego (lore), sin la necesidad de incluirlo con calzador en el propio juego. Esto último ha sido una experiencia muy chula para los participantes y no nos importaría seguir con ella.  
