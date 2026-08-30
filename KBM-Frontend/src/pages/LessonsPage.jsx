import { useState } from "react";
import { Link } from "react-router-dom";
import Navbar from "../components/Navbar";
import LessonGrid from "../components/LessonGrid";
import { lessons } from "../data/lessons";

function LessonsPage() {
  const [searchTerm, setSearchTerm] = useState("");
  const [groupByDepartment, setGroupByDepartment] = useState(false);

  const query = searchTerm.toLowerCase();

  const filteredLessons = lessons.filter((lesson) =>
    lesson.title.toLowerCase().includes(query) ||
    lesson.author.toLowerCase().includes(query) ||
    lesson.department.toLowerCase().includes(query)
  );

  return (
    <>
      <Navbar />

      <main className="lessons-page">

        <div className="breadcrumb">
          Home <span>›</span> Lessons Learned
        </div>

        <section className="page-header">

          <div>
            <h1>Lesson Learned</h1>

            <p>
              A dedicated space for automation engineers to reflect,
              share, and grow - documenting key takeaways, challenges,
              and solutions discovered during project lifecycles.
            </p>
          </div>

          <Link to="/create-lesson" className="primary-button">
            + Create Lesson
          </Link>

        </section>

        <div className="filters">

          <div className="search-box">
            ⌕

            <input
              type="text"
              placeholder="Search for a lesson..."
              value={searchTerm}
              onChange={(event) => setSearchTerm(event.target.value)}
            />
          </div>

        </div>

        <div className="group-container">
          <button
            type="button"
            className={`group-button ${groupByDepartment ? "active" : ""}`}
            onClick={() => setGroupByDepartment(!groupByDepartment)}
          >
            ◉ Group by Department
          </button>
        </div>

        <LessonGrid
          lessons={filteredLessons}
          groupByDepartment={groupByDepartment}
        />

      </main>
    </>
  );
}

export default LessonsPage;
