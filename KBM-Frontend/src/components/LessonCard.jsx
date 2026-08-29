import { Link } from "react-router-dom";

function LessonCard({ lesson }) {
    return (
        <Link to={`/lessons/${lesson.id}`} className="lesson-card-link">
            <article className="lesson-card">
                <div className="lesson-image">
                <img src={lesson.image} alt={lesson.title} />
        
                <span className={`category-badge ${lesson.categoryType}`}>
                    {lesson.category}
                </span>
                </div>
        
                <div className="lesson-content">
                <h3>{lesson.title}</h3>
        
                <div className="lesson-author">
                    <span className="author-avatar">
                    {lesson.department.charAt(0)}
                    </span>
        
                    <div>
                    <strong>{lesson.department}</strong>
                    <p>{lesson.role}</p>
                    </div>
                </div>
        
                <div className="lesson-rating">
                    <span className="stars">★★★★★</span>
                    <span>
                    ({lesson.reviews})
                    </span>
                </div>
        
                <div className="open-lesson-button">
                    Open Lesson →
                </div>
                </div>
            </article>
        </Link>

    );
  }
  
  export default LessonCard;