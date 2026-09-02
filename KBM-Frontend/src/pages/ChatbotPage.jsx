import { useState, useRef, useEffect } from "react";
import Navbar from "../components/Navbar";

const API_URL = `${import.meta.env.VITE_API_BASE_URL}/Chat`;

function ChatbotPage() {
  const [messages, setMessages] = useState([
    { sender: "bot", text: "Hello! How can I help you today?" },
  ]);
  const [input, setInput] = useState("");
  const [loading, setLoading] = useState(false);
  const chatEndRef = useRef(null);

  useEffect(() => {
    chatEndRef.current?.scrollIntoView({ behavior: "smooth" });
  }, [messages]);

  const sendMessage = async () => {
    const text = input.trim();
    if (!text || loading) return;

    setMessages((prev) => [...prev, { sender: "user", text }]);
    setInput("");
    setLoading(true);

    try {
      const response = await fetch(API_URL, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ message: text }),
      });

      if (!response.ok) throw new Error("Request failed");

      const data = await response.json();
      setMessages((prev) => [...prev, { sender: "bot", text: data.reply }]);
    } catch (err) {
      setMessages((prev) => [
        ...prev,
        { sender: "bot", text: "Something went wrong. Please try again." },
      ]);
    } finally {
      setLoading(false);
    }
  };

  const handleKeyDown = (e) => {
    if (e.key === "Enter") sendMessage();
  };

  return (
    <>
      <Navbar />
      <div className="page-container">
        <div className="breadcrumb">Home &gt; Chatbot</div>

        <div className="chatbot-page">
          <div className="chatbot-header">
            <div className="chatbot-icon">✦</div>
            <div>
              <h1>Knowledge Assistant</h1>
              <p>Ask questions about the lessons in the knowledge base.</p>
            </div>
          </div>

          <div className="chat-window">
            {messages.map((msg, i) => (
              <div
                key={i}
                className={`chat-message ${
                  msg.sender === "bot" ? "bot-message" : "user-message"
                }`}
              >
                <strong>{msg.sender === "bot" ? "Knowledge Assistant" : "You"}</strong>
                <p>{msg.text}</p>
              </div>
            ))}
            {loading && (
              <div className="chat-message bot-message">
                <strong>Knowledge Assistant</strong>
                <p>Typing...</p>
              </div>
            )}
            <div ref={chatEndRef} />
          </div>

          <div className="chat-input-container">
            <input
              type="text"
              placeholder="Ask something..."
              value={input}
              onChange={(e) => setInput(e.target.value)}
              onKeyDown={handleKeyDown}
            />
            <button className="primary-button" onClick={sendMessage} disabled={loading}>
              Send
            </button>
          </div>
        </div>
      </div>
    </>
  );
}

export default ChatbotPage;