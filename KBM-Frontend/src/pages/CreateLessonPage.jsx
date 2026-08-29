import { useState } from "react";
import Navbar from "../components/Navbar";


function CreateLessonPage() {
  const [title, setTitle] = useState("");
  const [projectName, setProjectName] = useState("");
  const [industry, setIndustry] = useState("");
  const [description, setDescription] = useState("");

  function handleSubmit(event) {
    event.preventDefault();

    console.log({
      title,
      projectName,
      industry,
      description,
    });
  }

  return (
    <>
    <Navbar />

    <div className="page-container">
      <div className="breadcrumb">
        Home &gt; Create Lesson
      </div>

      <div className="page-heading">
        <div className="page-icon">📄</div>

        <div>
          <h1>Create Lesson</h1>
          <p>
            Fill in the details below to create a new knowledge base lesson.
          </p>
        </div>
      </div>

      <div className="create-lesson-layout">
        <form onSubmit={handleSubmit}>
          <section className="form-section">
            <div className="section-title">
              <span>1</span>
              <h2>Basic Information</h2>
            </div>

            <div className="form-grid">
              <div className="form-group">
                <label>Lesson Title *</label>

                <input
                  type="text"
                  placeholder="Enter lesson title"
                  value={title}
                  onChange={(event) =>
                    setTitle(event.target.value)
                  }
                />
              </div>

              <div className="form-group">
                <label>Project Name *</label>

                <input
                  type="text"
                  placeholder="Enter project name"
                  value={projectName}
                  onChange={(event) =>
                    setProjectName(event.target.value)
                  }
                />
              </div>

              <div className="form-group full-width">
                <label>Industry *</label>

                <select
                  value={industry}
                  onChange={(event) =>
                    setIndustry(event.target.value)
                  }
                >
                  <option value="">Select industry</option>
                  <option value="Technology">Technology</option>
                  <option value="Telecommunications">
                    Telecommunications
                  </option>
                  <option value="Healthcare">Healthcare</option>
                  <option value="Finance">Finance</option>
                </select>
              </div>
            </div>
          </section>

          <section className="form-section">
            <div className="section-title">
              <span>2</span>
              <h2>Lesson Content</h2>
            </div>

            <div className="form-group">
              <label>Description *</label>

              <textarea
                placeholder="Write the full description of the lesson..."
                value={description}
                onChange={(event) =>
                  setDescription(event.target.value)
                }
              />
            </div>
          </section>

          <button type="submit" className="primary-button">
            Create Lesson
          </button>
        </form>

        <aside className="review-summary">
          <h2>Review Summary</h2>

          <div className="summary-section">
            <h3>BASIC INFORMATION</h3>

            <div className="summary-row">
              <span>Lesson Title</span>
              <strong>{title || "Not provided"}</strong>
            </div>

            <div className="summary-row">
              <span>Project Name</span>
              <strong>
                {projectName || "Not provided"}
              </strong>
            </div>

            <div className="summary-row">
              <span>Industry</span>
              <strong>
                {industry || "Not provided"}
              </strong>
            </div>
          </div>

          <div className="summary-section">
            <h3>LESSON CONTENT</h3>

            <div className="summary-row">
              <span>Description</span>
              <strong>
                {description ? "Provided" : "Not provided"}
              </strong>
            </div>
          </div>

          <div className="summary-note">
            All changes are saved as you type. You can submit
            the lesson when ready.
          </div>
        </aside>
      </div>
    </div>
    </>
  );
}

export default CreateLessonPage;