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
#### [5.1.2.- PERSONAJES](#mecanicas2)
#### [5.1.3.- COMBATE](#mecanicas3)
#### [5.1.4.- HABILIDADES](#mecanicas4)
#### [5.1.5.- ECONOMÍA](#mecanicas5)
#### [5.1.6.- RANKING](#mecanicas6)
### [5.2.- ESTADOS JUEGO](#estadosJuego)
### [5.3.- INTERFACES](#interfaces)
### [5.4.- CONTROLES](#controles)
### [5.5.- PROGRESO DEL JUEGO](#progresoDelJuego)
### [5.6.- NIVELES](#niveles)
## [6.- DISEÑO DEL MUNDO](#diseñoDelMundo)
### [6.1.- PERSONAJES](#personajes)
### [6.2.- LOCALIZACIONES](#localizaciones)
## [7.- ARTE](#arte)
### [7.1.- ESTILO Y REFERENCIAS](#estiloYReferncias)
### [7.2.- CONCEPTS](#arteFinal)
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

---
---

## 1.- FICHA RESUMEN <a name="fichaResumen"/>

| **NOMBRE**      | ???   |
| :-------------: | :---------------------:  |
| **VERSION**     | 1.0                      |
| **GENERO**      | Carreras                 |
| **TEMÁTICA**    | Espacio                  |
| **PLATAFORMA**  | Web (PC, Móvil o Tablet) |
| **JUEGOS RELACIONADOS**  | Slot Racing, Motorsport Manager |
| **PUBLICO OBJETIVO**     | Cualquier edad. Casual o experto      |
| **ESTILO VISUAL**        | 3D           |
| **CALIFICACIÓN**         | PEGI 3+                 |
| **IDIOMA**      | Español, Inglés          |
| **VISTA**       | ???              |
| **TECNOLOGÍAS** | Unity                   |
| **MECÁNICAS**   | - Corre contra otros cohetes <br> - Construye tu propio circuito <br>- Comparte tus circuitos con QR |

---

## 2.- HISTORIAL DE VERSIONES <a name="historialDeVersiones"/>

| **VERSION**     | **CAMBIOS DE VERSION**  |
| :-------------: |:---------------------:  |
| 1.0             | Versión Inicial         |

---
 
## 3.- SINOPSIS DEL JUEGO <a name="sinopsisDelJuego"/>

> ¡Bienvenidos a una nueva edición del Gran Premio Intergaláctico, la carrera más espectacular de todo el universo! ¿Qué nave te llevará al éxito interplanetario? Escoge con cabeza los mejores signos del Zodiaco y arrasa con todos los que se encuentren en tu camino.

> ??? es un juego de carreras en el que tendrás que ser el más rápido para poder triunfar, tanto en solitario con enemigos controlados por IA como en partidas multijuador de hasta cuatro participantes. Escoge una nave entre cuatro posibilidades: aire, agua, fuego y tierra y equípate dos de los doce signos del Zodiaco para alterar las características de tu vehículo. Puedes competir en los circuitos básicos o crear tus propios recorridos mediante el editor de circuitos. Además, podrás compartir estos niveles mediante ID o, si jugáis en dispositivos móviles, mediante código QR.

---

## 4.- CARACTERÍSTICAS PRINCIPALES <a name="caracteristicasPrincipales"/>

**- Diferentes tipos de carreras:** Al iniciar el juego, los jugadores podrán escoger entre una serie de modos de juego:
 *+ Rápido:* En este modo de juego se elegirá un circuito, tanto básicos como creados por los jugadores. Una vez elegido, los jugadores podrán empezar a competir, siendo el objetivo acabar la carrera antes que el resto de competidores, pudiendo ser estos jugadores reales o controlados por la IA. Las naves se moverán mediante un camino predeterminado y los jugadores solo podrán controlar la velocidad de su cohete mediante un elemento de la interfaz.
 *+ Temporada:* Este modo de juego es exclusivo para multijugador. Se elegirán una serie de circuitos los cuales se jugarán de forma continuada. En el último circuito se elegirá el ganador de la temporada, siendo el jugador que más puntos haya acumulado.
 *+ Simulador:* Este modo de juego es exclusivo para un jugador. El competidor se enfrentará a tres cohetes controlados por IA, pero no podrá controlar la velocidad de su propia nave. Para poder triunfar tendrá que ajustar su vehículo de la mejor forma posible para evitar cualquier imprevisto antes de empezar la partida.
 *+ Práctica:* En este modo de juego el jugador podrá probar sus combinaciones de nave + signos del Zodiaco de forma individual, sin competidores.
 
**- Naves:** Antes de empezar una partida, los jugadores podrán elegir una nave entre los cuatro tipos disponibles: aire, agua, fuego y tierra. Cada una de estas naves dispondrá de unas caarcterísticas iniciales distintas y podrá circular mejor en módulos afines a su elemento. Además, cada nave podrá equiparse dos signos del Zodiaco, los cuales aumentarán o disminuirán las características de las naves.

**- Editor de circuitos:** Los jugadores tendrán a su disposición un editor de circuitos por módulos. Existen distintos tipos de módulos: recta, curva, ... pudiendo girarlos y conectarlos entre sí para crear circuitos únicos. Estos circuitos se podrán compartir con cualquier persona que tenga el juego mediante códigos QR o IDs.

---

## 5.- DISEÑO DEL JUEGO	 <a name="diseñoDelJuego"/>
### 5.1.- MECÁNICAS			   <a name="mecanicas"/>
#### 5.1.1.- SISTEMA     <a name="mecanicas1"/>

Antes de iniciar una partida, cada jugador deberá elegir una nave espacial. Estas naves se dividen en los cuatro elementos: aire, agua, fuego y tierra. Cada uno de estos cohetes tiene unas estadísticas diferentes y una habilidad especial.

Una vez elegida una nave, los jugadores tendrán que elegir qué signos del Zodiaco podrán equipar a sus vehículos. Cada nave podrá equiparse dos signos, que alterarán las características de cada nave, pudiendo tanto aumentar algunas como disminuir otras.

Al terminar la personalización de las naves, los jugadores pasarán a elegir circuitos. En esta pantalla se mostrarán tanto los circuitos básicos, los creados por el jugador y los descargados mediante código QR. Si la partida es en solitario, el circuito escogido por el jugador será el elegido. En caso de multijugador, cada jugador podrá elegir un circuito en un máximo de 30 segundos. Una vez elegidos los circuitos se jugará al más votado o, en caso de empate, se elegirá de forma aleatoria entre los circuitos empatados.

Al empezar una carrera los jugadores serán colocados en sus respectivas líneas. El jugador 1 siempre será colocado en la línea más externa del circuito y el resto de cohetes, sean jugadores o controlador por IA, serán colocados en las líneas contiguas. Si se juega de forma individual, el resto de líneas serán cubiertas por naves controladas por IA. Estas naves se generarán de forma aleatoria, tanto su elemento como los signos del Zodiaco asignados. En cambio, en el modo multijugador, las líneas serán cubiertas por el resto de jugadores.

#### 5.1.2.- VEHÍCULOS  <a name="mecanicas2"/>



| **NOMBRE**      | **PERSONAJE**           | **ATK** | **HP** | **VEL** | **DPS** | **RAN** |
| :-------------: | :---------------------: | :-----: | :----: | :-----: | :-----: | :-----: |
| Atacante        | Tostada                 |    4    |   9    |   15    |    1    |    1    |
| Defensor        | Magdalena               |   2.5   |   15   |    5    |   0.65  |    1    |
| Distancia       | Bol de Cereales         |   3.5   |   7    |   10    |   1.5   |    5    |
| Velocista       | Robot Velocista         |    8    |   3    |   15    |    1    |    1    | 

#### 5.1.3.- SIGNOS DEL ZODIACO     <a name="mecanicas3"/>



#### 5.1.4.- REGLAJES <a name="mecanicas4"/>



#### 5.1.5.- CIRCUITOS    <a name="mecanicas5"/>



#### 5.1.6.- CONSTRUCTOR    <a name="mecanicas6"/>



### 5.2.- ESTADOS JUEGO	<a name="estadosJuego"/>

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/ESTADOS%20DEL%20JUEGO.png)

**INICIO**: Menú que se muestra al iniciar el juego. Hay 2 botones de configuración: *IDIOMA* y *SONIDO*<br>

- *JUGAR*: Empieza la partida.
- *RANKING*: Muestra las mejores puntuaciones por Nombre. Tiene un botón ATRÁS, que vuelve a **INICIO**.
- *CRÉDITOS*: Nombre del equipo y los desarrolladores. Tiene un botón *ATRÁS*, que vuelve a **INICIO**.
- *TIENDA*: Tienda del Juego. Tiene un botón *ATRÁS*, que vuelve a **INICIO**.
- *TUTORIAL*: Pantalla que muestra los controles. Tiene un botón *ATRÁS*, que vuelve a **INICIO**.

**JUEGO**: Pantallas del juego<br>

- *PRE-PARTIDA*: Los jugadores eligen el escenario y el modo de juego (Normal o Halloween). Si se elige el modo Dos Jugadores, hay dos fases de preparación. Si se elige el modo 1 jugador, aparecen sus niveles y solo hay una fase de preparación. Tiene un botón *ATRÁS*, que vuelve a **INICIO**.
- *FASE PREPARACIÓN*: Cada jugador coloca sus tropas antes del combate. Hay una (Un Jugador) o una por jugador (Dos Jugadores). Hay 2 botones de configuración: *IDIOMA* y *SONIDO*. Tiene un botón *ATRÁS*, que va a **GAME OVER**.
- *COMBATE*: Gameplay en tiempo real de la batalla. Tiene botones para controlar el juego. Tiene un botón de *SONIDO*. Tiene un botón *ATRÁS*, que va a **GAME OVER**.
- *RECUENTO RONDA*: Se cuentan los puntos para ver quien gana la ronda, se muestra mediante una tabla resumen. Cuando se pasa 5 veces por esta pantalla, la siguiente será **GAME OVER**. Tiene un botón *ATRÁS*, que va a **GAME OVER**.
- *GAME OVER*: Pantalla final del juego, donde se muestra el ganador y los puntos conseguidos.

**TUTORIAL**

- *PERSONAJES*: Muestra estadísticas avanzadas, para jugadores más experimentados. Al ser para niños, se evita mostrar este tipo de contenido. Tiene un botón *ATRÁS*, que vuelve a **TUTORIAL**.
- *HABILIDADES*: Muestra la descripción de las habilidades. Tiene un botón *ATRÁS*, que vuelve a **TUTORIAL**.
- *DESCRIPCION*: Describe a grandes rasgos como funciona el juego y los modos que hay. Tiene un botón *ATRÁS*, que vuelve a **TUTORIAL**.
- *FASES*: Explica las distitas fases del juego (Preparación y Combate). Tiene un botón *ATRÁS*, que vuelve a **TUTORIAL**.
- *CONTROLES*: Explica los controles: en ordenador, se gestionan con el ratón; y en el móvil, pulsando de manera táctil. Tiene un botón *ATRÁS*, que vuelve a **TUTORIAL**.

**TIENDA**: Pantallas de la tienda. Se pasan a través de Pestañas Botón. <br>

- *SKINS*: Lista de las Skins que se pueden comprar, el precio y la moneda necesaria (en cada caso).
- *PREMIOS*: Lista de los Premios canjeables y su precio, siempre en CeReal Currency (CC).
- *COMPRAR*: Pantalla que conecta con los métodos de pago para comprar Ataraxia Coins. Ventana de confirmación y contactos extra con los métodos de pago. 

### 5.3.- INTERFACES	<a name="interfaces"/>

`EJEMPLO:`

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/ESTADOS%20DEL%20JUEGO.png)

### 5.4.- CONTROLES	<a name="controles"/>

Al poderse jugar en diferentes plataformas, se usan 2 sets de controles: PC y móvil. 

**CONTROLES PC**

Basado en el ratón. (Al solo tener una Habilidad por Ronda, y que no se conserve entre ellas, no hay necesidad de hacer controles de Teclado. Esto ocurre porque solo un jugador tiene la posibilidad de usar la Habilidad, por lo que no hay conflictos. En versiones posteriores del juego esto puede cambiar hacia unos controles de teclado, que dividan los controles en 2.)

*Controles Menú* <br>
`Ratón`: Seleccionar entre opciones<br>
`Click Izq Ratón`: Elegir opción

*Jugadores*<br>
`Click Izq Ratón a la habilidad en su respectiva interfaz`: Selecciona la Habilidad, y si necesitas elegir una linea, te muestra flechas en las diferentes líneas para poder seleccionar a cual de ellas aplicar la Habilidad.

**CONTROLES MÓVIL Y TABLETA**

Basado en el control táctil. Los mismos controles para los dos jugadores, un tipo de botón para cada uno. Los Menús se controlan con botones táctiles.

*Jugadores*<br>
`FLECHAS DE LÍNEA`: Elegir línea. Solo hay que hacerlo cuando se resaltan.<br>
`ICONO DE UNIDADES`: Al pulsar, cambias la unidad seleccionada.<br>
`ICONO DE HABILIDADES`: Al pulsar,activas la habilidad acumulada.<br>

*Botones Extra*<br>
`SALIR`: Sale al menú principal

### 5.5.- PROGRESO DEL JUEGO	<a name="progresoDelJuego"/>



El consiguiente progreso se verá reflejado en el ranking de puntuaciones, donde se encuentran los mejores jugadores.

### 5.6.- MODOS DE JUEGO	<a name="niveles"/>

Según el número de jugadores que quieran jugar, se ofrecen 2 opciones de juego:

- **PARTIDA RÁPIDA**: Basado en Juego Solitario Local.

- **MODO TEMPORADA**: Basado en Juego Solitario Local. 


## 6.- DISEÑO DEL MUNDO	<a name="diseñoDelMundo"/>
### 6.1.- PERSONAJES	<a name="personajes"/>

- **EJEMPLO:**

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/ESTADOS%20DEL%20JUEGO.png)


### 6.2.- LOCALIZACIONES	<a name="localizaciones"/>

Este apartado se refiere a los diferentes escenarios visuales en los que se desarrolla el juego:

- **EJEMPLO:**

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/ESTADOS%20DEL%20JUEGO.png)

---

## 7.- ARTE	<a name="arte"/>
### 7.1.- ESTILO Y REFERENCIAS<a name="estiloYReferencias"/>	

- **EJEMPLO:**

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/ESTADOS%20DEL%20JUEGO.png)


### 7.2.- ARTE FINAL	<a name="arteFinal"/>

- **EJEMPLO:**

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/ESTADOS%20DEL%20JUEGO.png)

### 7.3.- ARTE PROMOCIONAL	<a name="artePromocional"/>

- **EJEMPLO:**

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/ESTADOS%20DEL%20JUEGO.png)

---

## 8.- SONIDO	<a name="sonido"/>

REFERENCIAS

### 8.1.- BANDA SONORA	<a name="bandaSonora"/>


- *Tema Menú*: Cartoon Fun Holidays by Hadwin Channel<br>

### 8.2.- EFECTOS DE SONIDO	<a name="efectosDeSonido"/>

Realizados con sonidos reales modificados a través de Audacity.

- *Grito 1*

---

## 9.- NARRATIVA Y GUION	<a name="narrativaYGuion"/>
### 9.1.- SINOPSIS <a name="sinopsis"/>	



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



### 10.3.- MODELO DE NEGOCIO <a name="modeloDeNegocio"/>

*MODELO DE NEGOCIO*



*MONETIZACION*



*PLAN DE NEGOCIO*



*PUBLICO META*



- **MODELO DE LIENZO:**

![alt text](https://github.com/AtaraxiaDevs/TeamRockets/blob/main/GDD/ESTADOS%20DEL%20JUEGO.png)

### 10.3.- MARKETING <a name="modeloDeNegocio"/>

## 11.- POST MORTEM	<a name="postMortem"/>

COSAS DEL POST MORTEM

