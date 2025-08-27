// Program.cs
using LangChain.Chains;
using LangChain.Memory;
using LangChain.Providers;
using LangChain.Providers.Ollama;
using static LangChain.Chains.Chain;

internal class Program
{
    private static async Task Main()
    {
        // 1) Bind to local Ollama with gpt-oss:20b
        //    Default URL is http://localhost:11434 (no key needed).
        var provider = new OllamaProvider(); // configure url: new OllamaProvider(url: "http://localhost:11434")
        var model = new OllamaChatModel(provider, id: "gpt-oss:20b"); // .UseConsoleForDebug();

        // 2) Simple conversational prompt template + memory
        var template = """
        The following is a friendly conversation between a human and an AI.
        Keep responses concise but helpful.

        {history}
        Human: {input}
        AI:
        """;

        // Use a basic in-memory history, and a buffer memory strategy.
        BaseChatMessageHistory chatHistory = new ChatMessageHistory();
        var memory = new ConversationBufferMemory(chatHistory)
        {
            // Match prefixes used in the prompt:
            Formatter = new MessageFormatter { AiPrefix = "AI", HumanPrefix = "Human" }
        };

        // 3) Build the chain once; we’ll prepend Set(input) each turn
        var chain =
            LoadMemory(memory, outputKey: "history")
            | Template(template)
            | LLM(model)
            | UpdateMemory(memory, requestKey: "input", responseKey: "text");

        Console.WriteLine("Multi-turn chat ready (type 'exit' to quit).\n");
        while (true)
        {
            Console.Write("You: ");
            var input = Console.ReadLine() ?? "";
            if (input.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase)) break;

            // Prepend the user turn and run the chain
            var response = await (Set(input, "input") | chain).RunAsync("text");
            Console.WriteLine($"AI: {response}\n");
        }
    }
}
