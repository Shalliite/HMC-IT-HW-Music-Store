class Factory {
    static ConvertToHtmlDocument(text) {
        var parser = new DOMParser();
        var html = parser.parseFromString(text, "text/html");
        return html;
    }
}