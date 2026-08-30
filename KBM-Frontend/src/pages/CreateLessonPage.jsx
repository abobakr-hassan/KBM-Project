import { useRef, useState } from "react";
import { useNavigate } from "react-router-dom";
import Navbar from "../components/Navbar";

function CreateLessonPage() {
  const navigate = useNavigate();

  const [title, setTitle] = useState("");
  const [projectName, setProjectName] = useState("");
  const [industry, setIndustry] = useState("");
  const [section, setSection] = useState("");
  const [description, setDescription] = useState("");
  const [imageFiles, setImageFiles] = useState([]);
  const [docFiles, setDocFiles] = useState([]);
  const [status, setStatus] = useState("Not provided");

  const imageInputRef = useRef(null);
  const docInputRef = useRef(null);

  const totalFiles = imageFiles.length + docFiles.length;

  function handleDiscard() {
    setTitle("");
    setProjectName("");
    setIndustry("");
    setSection("");
    setDescription("");
    setImageFiles([]);
    setDocFiles([]);
    setStatus("Not provided");
    navigate("/lessons");
  }

  function handleSaveDraft() {
    setStatus("Draft");
  }

  function handleSubmit(event) {
    event.preventDefault();
    setStatus("Submitted");
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
                    onChange={(event) => setTitle(event.target.value)}
                  />
                </div>

                <div className="form-group">
                  <label>Project Name *</label>

                  <input
                    type="text"
                    placeholder="Enter project name"
                    value={projectName}
                    onChange={(event) => setProjectName(event.target.value)}
                  />
                </div>

                <div className="form-group">
                  <label>Industry *</label>

                  <select
                    value={industry}
                    onChange={(event) => setIndustry(event.target.value)}
                  >
                    <option value="">Select industry</option>
                    <option value="Manufacturing">Manufacturing</option>
                    <option value="Technology">Technology</option>
                    <option value="Healthcare">Healthcare</option>
                    <option value="Finance">Finance</option>
                  </select>
                </div>

                <div className="form-group">
                  <label>Section</label>

                  <input
                    type="text"
                    placeholder="Enter section"
                    value={section}
                    onChange={(event) => setSection(event.target.value)}
                  />
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
                  onChange={(event) => setDescription(event.target.value)}
                />
              </div>
            </section>

            <section className="form-section">
              <div className="section-title">
                <span>3</span>
                <h2>Attachments</h2>
              </div>

              <div className="attachments-grid">
                <div
                  className="upload-box"
                  onClick={() => imageInputRef.current.click()}
                >
                  <div className="upload-icon">🖼</div>
                  <p>Click to upload or drag and drop</p>
                  <span>SVG, PNG, JPG or GIF (max 5MB)</span>
                  <span>Image uploads</span>

                  <input
                    ref={imageInputRef}
                    type="file"
                    accept=".svg,.png,.jpg,.jpeg,.gif"
                    multiple
                    hidden
                    onChange={(event) =>
                      setImageFiles([...imageFiles, ...event.target.files])
                    }
                  />
                </div>

                <div
                  className="upload-box"
                  onClick={() => docInputRef.current.click()}
                >
                  <div className="upload-icon">📎</div>
                  <p>Click to upload or drag and drop</p>
                  <span>PDF, DOCX, or PPTX (max 5MB)</span>
                  <span>Document uploads</span>

                  <input
                    ref={docInputRef}
                    type="file"
                    accept=".pdf,.docx,.pptx"
                    multiple
                    hidden
                    onChange={(event) =>
                      setDocFiles([...docFiles, ...event.target.files])
                    }
                  />
                </div>
              </div>

              {totalFiles === 0 ? (
                <p className="no-files">No files attached yet.</p>
              ) : (
                <p className="no-files">
                  {[...imageFiles, ...docFiles]
                    .map((file) => file.name)
                    .join(", ")}
                </p>
              )}
            </section>

            <div className="form-actions">
              <button
                type="button"
                className="discard-button"
                onClick={handleDiscard}
              >
                Discard
              </button>

              <div className="form-actions-right">
                <button
                  type="button"
                  className="secondary-button"
                  onClick={handleSaveDraft}
                >
                  Save as Draft
                </button>

                <button type="submit" className="primary-button">
                  Submit Lesson →
                </button>
              </div>
            </div>
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
                <strong>{projectName || "Not provided"}</strong>
              </div>

              <div className="summary-row">
                <span>Industry</span>
                <strong>{industry || "Not provided"}</strong>
              </div>

              <div className="summary-row">
                <span>Section</span>
                <strong>{section || "Not provided"}</strong>
              </div>
            </div>

            <div className="summary-section">
              <h3>LESSON CONTENT</h3>

              <div className="summary-row">
                <span>Description</span>
                <strong>{description ? "Provided" : "Not provided"}</strong>
              </div>
            </div>

            <div className="summary-section">
              <h3>ATTACHMENTS</h3>

              <div className="summary-row">
                <span>Files</span>
                <strong>{totalFiles} items</strong>
              </div>

              <div className="summary-row">
                <span>Status</span>
                <strong>{status}</strong>
              </div>
            </div>

            <div className="summary-note">
              All changes are saved as you type. You can save a draft or
              submit when ready.
            </div>
          </aside>
        </div>
      </div>
    </>
  );
}

export default CreateLessonPage;
