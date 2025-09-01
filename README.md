# LLM Demos - .NET Generative AI Playground

This solution is designed for testing and experimenting with different .NET frameworks and libraries to build Generative AI applications and AI Agents. It provides a structured environment to explore various AI providers, chat interfaces, and LLM integrations.

## 📋 Current Projects

### 1. LangChainChat-01
- **Framework**: .NET 9.0
- **Dependencies**: 
  - LangChain (v0.17.0) - Comprehensive LLM framework
  - LangChain.Providers.Ollama (v0.17.0) - Ollama integration
- **Description**: A conversational AI chat application using LangChain with memory management and Ollama integration
- **Features**:
  - Multi-turn conversations with memory
  - Template-based prompting
  - Local Ollama model integration (gpt-oss:20b)

### 2. Ollama-MS-AI-Extension-Chat-01
- **Framework**: .NET 9.0
- **Dependencies**:
  - Microsoft.Extensions.AI (v9.8.0) - Microsoft's AI abstraction layer
  - OllamaSharp (v5.3.6) - .NET client for Ollama
- **Description**: A streamlined chat application using Microsoft's AI extensions with real-time streaming responses
- **Features**:
  - Real-time streaming responses
  - Chat history management
  - Direct Ollama API integration

## 🚀 Getting Started

### Prerequisites
- .NET 9.0 SDK
- Ollama installed and running locally on port 11434
- VS Code with C# Dev Kit extension

### Running the Projects
1. **Build the entire solution**:
   ```bash
   dotnet build LLM-demos.sln
   ```

2. **Run individual projects**:
   ```bash
   # LangChain demo
   dotnet run --project LangChainChat-01/LangChainChat-01.csproj
   
   # Microsoft AI Extensions demo
   dotnet run --project Ollama-MS-AI-Extension-Chat-01/Ollama-MS-AI-Extension-Chat-01.csproj
   ```

3. **Using VS Code Debug**: Use F5 or the Run and Debug panel to launch any configured project.

## 🔧 Adding New Projects to the Solution

### Step 1: Create a New Console Project
```bash
# Navigate to the solution root
cd /path/to/LLM-demos

# Create a new console project
dotnet new console -n YourNewProject-01 -f net9.0

# Add the project to the solution
dotnet sln LLM-demos.sln add YourNewProject-01/YourNewProject-01.csproj
```

### Step 2: Install Required Packages
```bash
# Navigate to your new project directory
cd YourNewProject-01

# Example: Add common AI packages
dotnet add package Microsoft.Extensions.AI
dotnet add package OpenAI
# or
dotnet add package LangChain
dotnet add package LangChain.Providers.OpenAI
```

### Step 3: Add Build Task to tasks.json
Edit `.vscode/tasks.json` and add a new task:

```json
{
    "label": "build-yournewproject",
    "command": "dotnet",
    "type": "process",
    "args": [
        "build",
        "${workspaceFolder}/YourNewProject-01/YourNewProject-01.csproj",
        "/property:GenerateFullPaths=true",
        "/consoleloggerparameters:NoSummary"
    ],
    "problemMatcher": "$msCompile"
}
```

### Step 4: Add Debug Configuration to launch.json
Edit `.vscode/launch.json` and add a new configuration:

```json
{
    "name": "Launch YourNewProject-01",
    "type": "coreclr",
    "request": "launch",
    "preLaunchTask": "build-yournewproject",
    "program": "${workspaceFolder}/YourNewProject-01/bin/Debug/net9.0/YourNewProject-01.dll",
    "args": [],
    "cwd": "${workspaceFolder}/YourNewProject-01",
    "console": "internalConsole",
    "stopAtEntry": false
}
```

### Step 5: Verify the Setup
```bash
# Build the solution to ensure everything is configured correctly
dotnet build LLM-demos.sln

# Test the new project
dotnet run --project YourNewProject-01/YourNewProject-01.csproj
```

## 🛠️ VS Code Configuration

### Current Tasks (tasks.json)
- `build-langchain`: Builds the LangChain demo project
- `build-ollama`: Builds the Ollama MS AI Extension demo
- `build-solution`: Builds the entire solution

### Current Launch Configurations (launch.json)
- `Launch LangChainChat-01`: Debug configuration for LangChain demo
- `Launch Ollama-MS-AI-Extension-Chat-01`: Debug configuration for Ollama demo

### Tips for Adding New Configurations
1. **Task naming convention**: Use `build-{projectname}` format
2. **Launch configuration naming**: Use `Launch {ProjectName}` format
3. **Console setting**: Use `"console": "internalConsole"` for interactive applications
4. **PreLaunchTask**: Always reference the corresponding build task

## 📝 Project Structure Template

When creating new projects, follow this structure:
```
YourNewProject-01/
├── YourNewProject-01.csproj
├── Program.cs
├── README.md (optional - project-specific documentation)
├── bin/ (generated)
└── obj/ (generated)
```

## 🎯 Recommended AI Libraries to Explore

### Core AI Frameworks
- **Microsoft.Extensions.AI** - Microsoft's unified AI abstraction
- **LangChain** - Comprehensive LLM framework with chains and agents
- **Semantic Kernel** - Microsoft's AI orchestration framework

### LLM Providers
- **OpenAI** - GPT models (requires API key)
- **Azure.AI.OpenAI** - Azure OpenAI services
- **Anthropic** - Claude models
- **OllamaSharp** - Local Ollama integration
- **Google.AI.Generative** - Google Gemini models

### Specialized Libraries
- **Microsoft.SemanticKernel.Plugins.Memory** - Vector databases and embeddings
- **LangChain.Databases.Chroma** - Vector database integration
- **Microsoft.Extensions.AI.Abstractions** - AI service abstractions

## 🔍 Example Use Cases to Implement

1. **RAG (Retrieval Augmented Generation)** applications
2. **Multi-agent systems** with different AI personalities
3. **Function calling** and tool integration
4. **Vector database** integration for semantic search
5. **Different prompt engineering** techniques
6. **AI model comparison** and benchmarking
7. **Streaming vs. non-streaming** response handling

## 📚 Resources

- [Microsoft.Extensions.AI Documentation](https://learn.microsoft.com/en-us/dotnet/ai/)
- [LangChain .NET Documentation](https://github.com/tryAGI/LangChain)
- [Semantic Kernel Documentation](https://learn.microsoft.com/en-us/semantic-kernel/)
- [Ollama Documentation](https://ollama.ai/docs)

## 🤝 Contributing

Feel free to add new demo projects following the established patterns. Each project should:
1. Use .NET 9.0 as the target framework
2. Include proper documentation in comments
3. Follow the naming convention: `{Purpose}-{SequenceNumber}`
4. Add corresponding VS Code tasks and launch configurations