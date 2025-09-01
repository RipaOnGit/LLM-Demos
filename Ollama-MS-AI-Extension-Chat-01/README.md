# Ollama MS AI Extension Chat

A C# console application demonstrating integration between Microsoft.Extensions.AI and Ollama for local AI model interaction.

## Overview

This project showcases how to build a conversational AI chat application using Microsoft's AI extensions framework with Ollama as the backend model provider. The application provides a simple console-based chat interface that maintains conversation history and streams responses in real-time.

## Features

- **Local AI Model Integration**: Uses Ollama to run AI models locally without cloud dependencies
- **Microsoft.Extensions.AI**: Leverages Microsoft's standardized AI framework for .NET
- **Streaming Responses**: Real-time streaming of AI responses for better user experience
- **Conversation History**: Maintains chat context throughout the conversation
- **Simple Console Interface**: Easy-to-use command-line chat interface

## Prerequisites

- .NET 9.0 SDK
- [Ollama](https://ollama.ai/) installed and running locally
- The "gpt-oss:20b" model downloaded in Ollama

## Installation

1. **Install Ollama**: Follow the instructions at [ollama.ai](https://ollama.ai/) to install Ollama on your system.

2. **Download the required model**:
   ```bash
   ollama pull gpt-oss:20b
   ```

3. **Start Ollama server**:
   ```bash
   ollama serve
   ```
   (The server should be running on `http://localhost:11434/`)

4. **Clone and build the project**:
   ```bash
   git clone <repository-url>
   cd Ollama-MS-AI-Extension-Chat-01
   dotnet build
   ```

## Usage

1. **Run the application**:
   ```bash
   dotnet run
   ```

2. **Start chatting**:
   - Type your messages and press Enter
   - The AI will respond with streaming text
   - Type 'exit' to quit the application

## Configuration

The application is configured to use:
- **Ollama Server**: `http://localhost:11434/`
- **Model**: `gpt-oss:20b`

To use a different model, modify the model name in `Program.cs`:
```csharp
IChatClient chatClient = new OllamaApiClient(new Uri("http://localhost:11434/"), "your-model-name");
```

## Dependencies

- **Microsoft.Extensions.AI** (v9.8.0): Microsoft's AI framework for .NET
- **OllamaSharp** (v5.3.6): C# client library for Ollama API

## Architecture

The application follows a simple architecture:

1. **OllamaApiClient**: Connects to the local Ollama server
2. **IChatClient**: Microsoft.Extensions.AI interface for chat operations
3. **ChatMessage History**: Maintains conversation context
4. **Streaming Response**: Handles real-time AI response streaming

## Code Structure

```
├── Program.cs              # Main application entry point
├── *.csproj               # Project configuration and dependencies
└── README.md              # This documentation
```

## Example Session

```
GPT-OSS Chat - Type 'exit' to quit

You: Hello, how are you?
Assistant: Hello! I'm doing well, thank you for asking. I'm here and ready to help you with any questions or tasks you might have. How are you doing today?

You: Can you explain what Ollama is?
Assistant: Ollama is a tool that allows you to run large language models locally on your own machine...

You: exit
```

## References

This project is based on the Microsoft DevBlog post: [Building GPT-OSS Applications with C# and Ollama](https://devblogs.microsoft.com/dotnet/gpt-oss-csharp-ollama/)

## Troubleshooting

**Model not found error**: Ensure the `gpt-oss:20b` model is downloaded using `ollama pull gpt-oss:20b`

**Connection refused**: Verify Ollama server is running on port 11434 using `ollama serve`

**Slow responses**: Consider using a smaller model if performance is an issue

## License

This project is part of the LLM-demos repository and follows the same license terms.