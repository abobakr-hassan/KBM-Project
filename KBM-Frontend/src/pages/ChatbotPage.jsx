import Navbar from "../components/Navbar";

function ChatbotPage() {
  return (
    <>
      <Navbar />

      <div className="page-container">
        <div className="breadcrumb">
          Home &gt; Chatbot
        </div>

        <div className="chatbot-page">
          <div className="chatbot-header">
            <div className="chatbot-icon">✦</div>

            <div>
              <h1>Knowledge Assistant</h1>
              <p>
                Ask questions about the lessons in the knowledge base.
              </p>
            </div>
          </div>

          <div className="chat-window">
            <div className="chat-message bot-message">
              <strong>Knowledge Assistant</strong>
              <p>
                Hello! How can I help you today?
              </p>
            </div>
          </div>

          <div className="chat-input-container">
            <input
              type="text"
              placeholder="Ask something..."
            />

            <button className="primary-button">
              Send
            </button>
          </div>
        </div>
      </div>
    </>
  );
}

export default ChatbotPage;