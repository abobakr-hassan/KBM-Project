import { useParams } from "react-router-dom";
import { lessons } from "../data/lessons";

function LessonDetailsPage() {
  const { id } = useParams();

  const lesson = lessons.find((lesson) => lesson.id === Number(id));

  if (!lesson) {
    return (
      <div className="page-container">
        <h1>Lesson Not Found</h1>
        <p>The lesson you are looking for does not exist.</p>
      </div>
    );
  }

  return (
    <div className="page-container">
      <div className="breadcrumb">
        Home &gt; Lessons Learned &gt; {lesson.title}
      </div>

      <div className="lesson-details">
        <div className="lesson-details-image">
          <img src={lesson.image} alt={lesson.title} />
        </div>

        <div className="lesson-details-content">
          <span className="lesson-tag">{lesson.department}</span>

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

          <h2>Description</h2>
          <p>{lesson.description}</p>

          <h2>Value Proposition</h2>
          <p>{lesson.valueProposition}</p>
        </div>
      </div>
    </div>
  );
}

export default LessonDetailsPage;