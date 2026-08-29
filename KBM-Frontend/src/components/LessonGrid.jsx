import LessonCard from "./LessonCard";

function LessonGrid({ lessons }) {
  return (
    <div className="lesson-grid">
      {lessons.map((lesson) => (
        <LessonCard
          key={lesson.id}
          lesson={lesson}
        />
      ))}
    </div>
  );
}

export default LessonGrid;