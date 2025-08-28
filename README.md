# LLM-Demos

A collection of Large Language Model (LLM) demonstration applications built with C# and LangChain.

## LangChainChat-01

A simple console-based chatbot application that demonstrates how to build a conversational AI using LangChain with Ollama as the LLM provider.

### Features

- Interactive console chat interface
- Conversation memory (remembers chat history within the session)
- Uses Ollama's `gpt-oss:20b` model
- Clean exit with 'exit' command
- Concise but helpful AI responses

### Prerequisites

Before running this application, ensure you have the following installed:

1. **.NET 9.0 SDK**
   - Download from [https://dotnet.microsoft.com/download/dotnet/9.0](https://dotnet.microsoft.com/download/dotnet/9.0)

2. **Ollama**
   - Download and install from [https://ollama.ai](https://ollama.ai)
   - Make sure Ollama is running on your system

3. **GPT-OSS:20B Model**
   - After installing Ollama, pull the required model:
   ```bash
   ollama pull gpt-oss:20b
   ```

### Installation & Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/RipaOnGit/LLM-Demos.git
   cd LLM-Demos
   ```

2. **Navigate to the project directory:**
   ```bash
   cd LangChainChat-01
   ```

3. **Restore NuGet packages:**
   ```bash
   dotnet restore
   ```

4. **Ensure Ollama is running:**
   - Ollama should be running on `http://localhost:11434` (default port)
   - Verify by opening [http://localhost:11434](http://localhost:11434) in your browser

### Running the Application

1. **Build and run the application:**
   ```bash
   dotnet run
   ```

2. **Start chatting:**
   - The application will display "Multi-turn chat ready (type 'exit' to quit)."
   - Type your messages and press Enter
   - The AI will respond using the Ollama model
   - Type `exit` to quit the application

### Example Usage

```
Multi-turn chat ready (type 'exit' to quit).

You: Hello, how are you?
AI: Hello! I'm doing well, thank you for asking. I'm here and ready to help you with any questions or tasks you might have. How are you doing today?

You: What's the weather like?
AI: I don't have access to real-time weather information, so I can't tell you the current weather conditions. To get accurate weather information, I'd recommend checking a weather app, website like weather.com, or asking a voice assistant that has internet access.

You: exit
```

### Technical Details

- **Framework:** .NET 9.0
- **Dependencies:**
  - LangChain v0.17.0
  - LangChain.Providers.Ollama v0.17.0
- **LLM Provider:** Ollama
- **Model:** gpt-oss:20b
- **Memory:** Conversation buffer memory with in-memory storage

### Configuration

The application uses default settings:
- **Ollama URL:** `http://localhost:11434`
- **Model:** `gpt-oss:20b`
- **Memory Strategy:** Conversation buffer (stores full conversation history)

To modify these settings, edit the `Program.cs` file:

```csharp
// Change Ollama URL
var provider = new OllamaProvider(url: "http://your-ollama-host:port");

// Change model
var model = new OllamaChatModel(provider, id: "your-model-name");
```

### Troubleshooting

**Common Issues:**

1. **"Connection refused" error:**
   - Ensure Ollama is running
   - Check if Ollama is accessible at `http://localhost:11434`

2. **Model not found error:**
   - Make sure you've pulled the `gpt-oss:20b` model: `ollama pull gpt-oss:20b`
   - Verify available models: `ollama list`

3. **Build errors:**
   - Ensure you have .NET 9.0 SDK installed
   - Run `dotnet restore` to restore packages

### Contributing

Feel free to submit issues and enhancement requests!

### License

This project is licensed under the terms included in the LICENSE file.