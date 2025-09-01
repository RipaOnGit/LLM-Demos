using Microsoft.Extensions.AI;
using OllamaSharp;

// Based on this blog https://devblogs.microsoft.com/dotnet/gpt-oss-csharp-ollama/
internal class Program
{
    private static async Task Main()
    {
        // Initialize OllamaApiClient targeting the "gpt-oss:20b" model
        IChatClient chatClient = new OllamaApiClient(new Uri("http://localhost:11434/"), "gpt-oss:20b");

        // Maintain conversation history
        List<ChatMessage> chatHistory = new();

        Console.WriteLine("GPT-OSS Chat - Type 'exit' to quit");
        Console.WriteLine();

        // Prompt user for input in a loop
        while (true)
        {
            Console.Write("You: ");
            var userInput = Console.ReadLine();

            if (userInput?.ToLower() == "exit")
                break;

            if (string.IsNullOrWhiteSpace(userInput))
                continue;

            // Add user message to chat history
            chatHistory.Add(new ChatMessage(ChatRole.User, userInput));

            // Stream the AI response and display in real time
            Console.Write("Assistant: ");
            var assistantResponse = "";

            await foreach (var update in chatClient.GetStreamingResponseAsync(chatHistory))
            {
                Console.Write(update.Text);
                assistantResponse += update.Text;
            }

            // Append assistant message to chat history
            chatHistory.Add(new ChatMessage(ChatRole.Assistant, assistantResponse));
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
