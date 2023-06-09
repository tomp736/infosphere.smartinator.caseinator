using System.Text.Json.Serialization;

namespace caseinator.core;

/// <summary>
/// Represents a case study for refactoring a user story, related to the Infosphere in the Futurama universe.
/// </summary>
public class Caseinator
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("background")]
    public string Background { get; set; }

    [JsonPropertyName("challenges")]
    public List<string> Challenges { get; set; }

    [JsonPropertyName("solutions")]
    public List<string> Solutions { get; set; }

    [JsonPropertyName("outcomes")]
    public List<string> Outcomes { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("user_story")]
    public string UserStory { get; set; }

    [JsonPropertyName("sources_of_complexity")]
    public List<string> SourceOfComplexity { get; set; }

    [JsonPropertyName("refactored_user_stories")]
    public List<string> RefactoredUserStories { get; set; }

    [JsonPropertyName("implementation_issues")]
    public List<string> ImplementationIssues { get; set; }

    [JsonPropertyName("lean_principles")]
    public List<string> LeanPrinciples { get; set; }

    [JsonPropertyName("agile_principles")]
    public List<string> AgilePrinciples { get; set; }

    [JsonPropertyName("summary")]
    public string Summary { get; set; }
}