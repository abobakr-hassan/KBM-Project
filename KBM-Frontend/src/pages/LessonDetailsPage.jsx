import { Link, useParams } from "react-router-dom";
import Navbar from "../components/Navbar";
import { lessons } from "../data/lessons";

function LessonDetailsPage() {
  const { id } = useParams();

  const lesson = lessons.find((lesson) => lesson.id === Number(id));

  if (!lesson) {
    return (
      <>
        <Navbar />
        <div className="page-container">
          <h1>Lesson Not Found</h1>
          <p>The lesson you are looking for does not exist.</p>
        </div>
      </>
    );
  }

  return (
    <>
      <Navbar />

      <div className="page-container">
        <div className="breadcrumb">
          Home &gt; Lessons Learned &gt; {lesson.title}
        </div>

        <div className="lesson-details-layout">
          <div className="lesson-details">
            <div className="lesson-details-image">
              <img src={lesson.image} alt={lesson.title} />
            </div>

            <div className="lesson-details-content">
              <div className="lesson-details-top">
                <span className="lesson-tag">{lesson.department}</span>
                <span className="share-button">↗ Share</span>
              </div>

              <h1>{lesson.title}</h1>

              <p className="lesson-author">
                By {lesson.personToContact}
              </p>

              <div className="lesson-rating">
                ⭐ {lesson.rating} ({lesson.reviews} reviews)
              </div>

              <hr />

              <h2>Project</h2>
              <p>{lesson.projectName}</p>

              <h2>Industry</h2>
              <p>{lesson.industry}</p>

              <h2>Value Proposition</h2>
              <p>{lesson.valueProposition}</p>

              <h2>Description</h2>
              <p>{lesson.description}</p>
            </div>
          </div>

          <aside className="lesson-sidebar">
            <div className="sidebar-block">
              <h3>ATTACHMENTS</h3>

              <ul className="attachment-list">
                {lesson.attachments.map((file) => (
                  <li key={file.name} className="attachment-item">
                    <div>
                      <strong>{file.name}</strong>
                      <p>
                        {file.size} · {file.type}
                      </p>
                    </div>
                  </li>
                ))}
              </ul>
            </div>

            <div className="sidebar-block">
              <h3>QUICK LINKS</h3>

              <ul className="quick-link-list">
                {lesson.quickLinks.map((link) => (
                  <li key={link.label}>
                    <a href={link.url}>∞ {link.label}</a>
                  </li>
                ))}
              </ul>
            </div>

            <div className="sidebar-block">
              <h3>KEYWORDS</h3>

              <div className="keyword-list">
                {lesson.keywords.map((keyword) => (
                  <span key={keyword} className="keyword-tag">
                    #{keyword}
                  </span>
                ))}
              </div>
            </div>

            <div className="sidebar-cta">
              <h3>Have a similar lesson?</h3>
              <p>
                Sharing your experience helps our engineering community
                grow stronger.
              </p>

              <Link to="/create-lesson" className="primary-button">
                + Create Lesson
              </Link>
            </div>
          </aside>
        </div>
      </div>
    </>
  );
}

export default LessonDetailsPage;
