# 🏢 Sala de Reuniões VR — Meu Primeiro Ambiente VR Interativo

## 📋 Apresentando o Projeto

Este projeto consiste em uma **Sala de Reuniões em Realidade Virtual**, desenvolvida com Unity 6 e Meta XR SDK. O ambiente simula um espaço corporativo completo e navegável, onde o usuário pode explorar o espaço livremente e interagir com os elementos da cena.

O ambiente conta com:
- 🚪 Uma **porta interativa** que abre e fecha
- 🪑 **Cadeiras e puffs** onde o jogador pode sentar e levantar
- 📺 Uma **televisão de 30"** para transmissões, com bancada ao lado
- 🪑 **Mesa de reunião** central com cadeiras ao redor
- 🛋️ Três **puffs** decorativos e funcionais
- Ambiente completo com paredes, teto, chão e iluminação

---

## 🌐 Contexto e Objetivos

O ambiente representa uma **sala de reuniões corporativa no contexto do Metaverso**, com o objetivo de simular um espaço de trabalho virtual onde equipes remotas poderiam se reunir, apresentar conteúdo em tela e colaborar em tempo real.

**Área de aplicação:** Comunicação e trabalho remoto no Metaverso  
**Público-alvo:** Profissionais e equipes corporativas  
**Objetivo no Metaverso:** Substituir reuniões presenciais por um ambiente imersivo e interativo

---

## 🎮 Como Usar o Projeto

### Requisitos
- Unity 6000.3.10f1 LTS
- Meta XR SDK instalado
- Abrir a cena em: `Assets/Scenes/SampleScene`

### Controles
| Tecla | Ação |
|-------|------|
| W / S | Andar para frente e para trás |
| A / D | Virar para esquerda e direita |
| Mouse | Olhar em todas as direções |
| E | Interagir (sentar, levantar, abrir/fechar porta) |
| Escape | Soltar o cursor do mouse |

### Interações disponíveis
- **Porta:** Aproxime-se e pressione **E** para abrir ou fechar
- **Cadeiras:** Aproxime-se e pressione **E** para sentar; pressione **E** novamente para levantar
- **Puffs:** Aproxime-se e pressione **E** para sentar; pressione **E** novamente para levantar

---

## ⚙️ Configuração Técnica

- **Engine:** Unity 6000.3.10f1 LTS
- **Template:** VR (com Meta XR SDK pré-configurado)
- **Render Pipeline:** Universal Render Pipeline (URP)
- **XR Plugin:** OpenXR com Meta Quest Feature Group
- **Plataforma:** Android (Meta Quest) + PC (Editor)
- **Movimentação no PC:** Implementada via script C# usando o novo Input System

---

## 🛠️ Processo de Criação e Dificuldades

### Como desenvolvi o projeto

1. **Base do projeto:** Utilizei o template VR do Unity, que já vem com XR Origin, sistema de teleporte e configurações do Meta XR SDK pré-configuradas.

2. **Montagem do ambiente:** Importei assets gratuitos da Unity Asset Store para montar a sala de reuniões, incluindo móveis, porta e televisão. Organizei todos os objetos na Hierarchy em grupos lógicos.

3. **Movimentação no PC:** O template VR por padrão só funciona com o óculos Quest. Para rodar no Editor, criei um script `MovimentacaoPC.cs` que usa o novo Input System do Unity para capturar teclado e mouse.

4. **Interação com a porta:** Criei o script `PortaInterativa.cs` que detecta a proximidade do jogador e abre/fecha a porta suavemente usando `Quaternion.Lerp`.

5. **Interação de sentar:** Criei o script `AssentoInterativo.cs` que move o jogador até um ponto de sentado predefinido em cada cadeira/puff, desativando e reativando o Character Controller durante o processo.

### Maiores dificuldades

**1. Sistema de Input do Unity 6**  
A maior dificuldade foi que o Unity 6 usa o novo Input System, incompatível com o `Input.GetAxis` tradicional. Ao usar o método antigo, apareciam erros `InvalidOperationException` no console. Resolvi substituindo por `Keyboard.current` e `Mouse.current` do pacote `UnityEngine.InputSystem`.

**2. Assets com materiais rosa (incompatíveis com URP)**  
Vários assets importados da Asset Store ficaram com cor rosa, pois seus materiais foram criados para o Built-in Render Pipeline. Resolvi convertendo os materiais em **Edit → Rendering → Materials → Convert All Built-in Materials to URP**.

**3. Câmera passando através dos objetos**  
Inicialmente a câmera atravessava paredes e objetos. Resolvi garantindo que o script de movimentação usasse o `CharacterController.Move()` em vez de `transform.Translate`, respeitando assim as colisões dos objetos.

**4. Posicionamento dos pontos de sentar**  
Foi necessário ajustar manualmente os `PontoDeSentado` em cada cadeira para que o jogador ficasse na posição correta ao sentar, evitando que a câmera ficasse dentro do objeto.

---

## 📝 Observações Finais

Este projeto foi desenvolvido como parte da **Residência em TIC 29 — Web 3.0**, unidade de Fundamentos do Metaverso. O ambiente cumpre todos os requisitos das atividades 1 e 2, incluindo configuração técnica completa, ambiente temático reconhecível, interações funcionais implementadas em C# e documentação detalhada.
