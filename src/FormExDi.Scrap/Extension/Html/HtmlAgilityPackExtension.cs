using HtmlAgilityPack;

namespace FormExDi.Scrap.Extension.Html;

internal static class HtmlAgilityPackExtension
{
    public static Dictionary<string, string> GetFormsParams(this HtmlNode htmlNode, in string formId = "form")
    {
        var dictionary = new Dictionary<string, string>();
        if (htmlNode is null)
            return dictionary;

        HtmlNode form = htmlNode.SelectSingleNode($"//form[@id='{formId}']");

        foreach (HtmlNode node in form.SelectNodes("//input"))
        {
            HtmlAttribute nameAttribute = node.Attributes["name"];
            HtmlAttribute valueAttribute = node.Attributes["value"];

            if (nameAttribute == null)
                continue;
            
            if (string.IsNullOrEmpty(nameAttribute.Value))
                continue;

            if (valueAttribute != null)
            {
                if (!dictionary.ContainsKey(nameAttribute.Value))
                    dictionary.Add(nameAttribute.Value, 
                        valueAttribute.Value ?? string.Empty);
                continue;
            }

            if (!dictionary.ContainsKey(nameAttribute.Value))
                dictionary.Add(nameAttribute.Value, string.Empty);
        }

        return dictionary;
    }
}