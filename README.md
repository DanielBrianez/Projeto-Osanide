🌿 Osanide Desktop App

Um projeto de loja de ervas feito em C# com .NET 8.0, com banco de dados em JSON, que gerencia produtos, funcionários e administradores de forma completa e segura.

Funcionalidades: login, cadastro, atualização, exclusão, reset de senha e permissões diferenciadas.

✨ Destaques

- Cadastro e atualização de produtos (nome, categoria, descrição, preço, estoque)
- Gerenciamento de usuários: funcionários e admins
- Sistema de login completo com validação e reset de senha
- Busca em tempo real para produtos e usuários
- Persistência de dados com JSON (sem SQL pesado)
- Interface limpa e intuitiva, com DataGridView customizado
- Modularidade com DTO / BLL / DAL

💻 Tecnologias

- C# .NET 8.0
- Windows Forms (WinForms)
- JSON para armazenamento local
- Arquitetura DTO / BLL / DAL

🗂️ Estrutura do Projeto
OsanideDesktop/
├─ DAL/          # Persistência JSON
├─ DTO/          # Objetos de transferência
├─ BLL/          # Regras de negócio
├─ Desktop/      # Forms e UserControls
│  ├─ ucProdutos.cs
│  └─ ucUsuarios.cs
├─ Data/         # JSONs gerados automaticamente
├─ Resources/    # Assets
└─ README.md

🚀 Como Usar

- Clone o projeto: git clone https://github.com/seu-usuario/osanide-desktop.git
- Abra no Visual Studio
- Compile e execute
- Cadastre produtos e usuários
- Faça login para acessar funções administrativas

🎨 Créditos

- BackEnd: Daniel Nascimento
- FrontEnd / Interface: Maryana Olvra (a musa do design ❤️)
