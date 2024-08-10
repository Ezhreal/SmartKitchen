# SmartKitchen - Plataforma de Cozinha Inteligente

## Visão Geral
A **SmartKitchen** é uma plataforma inovadora projetada para ajudar usuários a gerenciar suas necessidades alimentares, explorar novas receitas, e utilizar tecnologias avançadas como inteligência artificial para personalizar suas experiências culinárias.

## Funcionalidades Principais
- Gerenciamento completo de receitas.
- Sugestão de receitas com base em ingredientes disponíveis.
- Sugestão de receitas com base em restrição alimentar.
- Ajudar a identificar nas receitas e pratos alergênicos (glúten, lactose, alergias gerais) de acordo com a configuração.
- Sugestão através de IA para dietas especiais inclusas via arquivos (PDF, TXT, IMG).
- Sugestões para datas especiais e ocasiões temáticas.
- Aplicativo móvel para gerenciamento de receitas e listas de compras.
- Reconhecimento de pratos a partir de fotos e sugestões automáticas de receitas.
- Futura integração com dispositivos como Alexa para controle por voz.
- Integração internet das coisas (Ex. geladeira smart).

## Tecnologias Utilizadas
- **Back-end:** C#, ASP.NET Core, SQL Server
- **Front-end:** React, React Native
- **Inteligência Artificial:** Python, TensorFlow/Keras
- **Controle de Versão:** Git, GitHub

## Estrutura do Projeto

```plaintext
/SmartKitchen
│
├── /backend
│   ├── /src                     # Código-fonte do back-end
│   │   ├── /API                 # Controladores e endpoints da API
│   │   ├── /Services            # Lógica de negócios e serviços
│   │   ├── /Models              # Modelos de dados (Entidades)
│   │   └── /Data                # Contexto de banco de dados e migrações (Entity Framework)
│   │
│   ├── /tests                   # Testes unitários e de integração para o back-end
│   │   └── /UnitTests           # Testes unitários para serviços e controladores
│   │
│   ├── /config                  # Configurações do projeto (appsettings, configs)
│   │   ├── appsettings.json     # Configurações gerais da aplicação
│   │   └── logging.json         # Configurações de logging
│   │
│   └── /docs                    # Documentação técnica do back-end
│
├── /frontend
│   ├── /web
│   │   ├── /public              # Arquivos públicos (index.html, favicon, etc.)
│   │   ├── /src                 # Código-fonte do front-end web
│   │   │   ├── /components      # Componentes React reutilizáveis
│   │   │   ├── /pages           # Páginas da aplicação (ex.: Home, Dashboard)
│   │   │   ├── /services        # Serviços para integração com a API
│   │   │   ├── /styles          # Arquivos de estilo (CSS, SASS, etc.)
│   │   │   ├── /assets          # Imagens, ícones, fontes, etc.
│   │   │   └── /hooks           # Custom Hooks do React
│   │   │
│   │   └── /tests               # Testes para o front-end web
│   │       └── /unit            # Testes unitários para componentes
│   │
│   └── /mobile
        ├── /src
        │   ├── /components      # Componentes React Native reutilizáveis
        │   ├── /screens         # Telas do aplicativo (ex.: Home, Login)
        │   ├── /services        # Serviços para integração com a API
        │   ├── /assets          # Imagens, ícones, fontes, etc.
        │   ├── /styles          # Arquivos de estilo (CSS, SASS, etc.)
        │   └── /hooks           # Custom Hooks para React Native
        │
        ├── /android             # Código específico para a versão Android (se necessário)
        ├── /ios                 # Código específico para a versão iOS (se necessário)
        │
        └── /tests
            └── /e2e             # Testes end-to-end para o aplicativo mobile
│
├── /ai
│   ├── /models                  # Modelos de IA treinados
│   │   ├── /training            # Scripts e notebooks para treinamento de modelos
│   │   ├── /inference           # Scripts para inferência de modelos em produção
│   │   └── /datasets            # Dados usados para treinar modelos
│   │
│   ├── /notebooks               # Jupyter notebooks para experimentos
│   │
│   └── /tests                   # Testes para modelos de IA
│
├── /docs
│   ├── /requirements            # Documentação da API (ex.: Swagger, Postman)
│   ├── /architecture            # Diagramas e documentação arquitetural
│   └── /user-guide              # Manual do usuário e documentação geral
│
└── /ci-cd                       # Configurações de integração contínua e entrega contínua (CI/CD)
    ├── /github                  # Workflows do GitHub Actions
    ├── /docker                  # Dockerfiles e scripts de containerização
    └── /scripts                 # Scripts de automação e deploy
