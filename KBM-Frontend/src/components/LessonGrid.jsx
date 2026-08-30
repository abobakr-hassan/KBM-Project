import LessonCard from "./LessonCard";

function LessonGrid({ lessons, groupByDepartment = false }) {
  if (lessons.length === 0) {
    return (
      <div className="empty-state">
        No lessons match your search.
      </div>
    );
  }

  if (!groupByDepartment) {
    return (
      <div className="lesson-grid">
        {lessons.map((lesson) => (
          <LessonCard key={lesson.id} lesson={lesson} />
        ))}
      </div>
    );
  }

  const groups = lessons.reduce((acc, lesson) => {
    const department = lesson.department || "Other";

    if (!acc[department]) {
      acc[department] = [];
    }

    acc[department].push(lesson);

    return acc;
  }, {});

  return (
    <div className="lesson-groups">
      {Object.entries(groups).map(([department, groupLessons]) => (
        <section key={department} className="lesson-group">
          <h2 className="lesson-group-title">
            {department}
            <span className="lesson-group-count">
              {groupLessons.length}
            </span>
          </h2>

          <div className="lesson-grid">
            {groupLessons.map((lesson) => (
              <LessonCard key={lesson.id} lesson={lesson} />
            ))}
          </div>
        </section>
      ))}
    </div>
  );
}

export default LessonGrid;
