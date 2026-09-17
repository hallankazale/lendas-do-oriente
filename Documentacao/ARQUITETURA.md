# Arquitetura inicial

## Objetivo
Separar regras de jogo da apresentação e dos componentes específicos da cena.

## Estrutura planejada

```text
Assets/
├── Arte/
│   ├── Personagens/
│   ├── Cenarios/
│   ├── Equipamentos/
│   └── Efeitos/
├── Audio/
├── Cenas/
│   └── VilaDasCerejeiras/
├── Codigo/
│   ├── Core/
│   ├── Jogador/
│   ├── Camera/
│   ├── Combate/
│   ├── NPC/
│   ├── Missoes/
│   ├── Inventario/
│   └── Interface/
├── Dados/
├── Prefabs/
└── Testes/
```

## Princípios
- Sistemas desacoplados e componentes pequenos.
- Dados de itens, habilidades e inimigos separados da lógica sempre que possível.
- Nenhuma chave, token ou segredo dentro do projeto cliente.
- Entradas do usuário validadas antes de afetarem estado persistente.
- Dependências de multiplayer não serão misturadas ao protótipo single-player.

## Fluxo do primeiro protótipo
Menu -> Vila das Cerejeiras -> Movimento -> Interação com NPC -> Combate -> XP -> Loot -> Inventário.

## Android
A meta inicial é manter uma experiência fluida em aparelhos intermediários. O orçamento de renderização será definido após o primeiro profiling em dispositivo real.