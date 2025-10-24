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

Clone o projeto:

git clone https://github.com/seu-usuario/osanide-desktop.git


Abra no Visual Studio

Compile e execute

Cadastre produtos e usuários

Faça login para acessar funções administrativas

🎨 Créditos

BackEnd: Daniel Nascimento

FrontEnd / Interface: Maryana Olvra (a musa do design ❤️)

📄 Licença MIT
MIT License

Copyright (c) 2025 Daniel Nascimento

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
