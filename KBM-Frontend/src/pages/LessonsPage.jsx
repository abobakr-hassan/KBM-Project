import Navbar from "../components/Navbar";
import LessonGrid from "../components/LessonGrid";
import { lessons as initialLessons } from "../data/lessons";
import { Link } from "react-router-dom";

function LessonsPage() {
  const lessons = initialLessons;

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

        <section className="filters">

          <div className="search-box">
            ⌕

            <input
              type="text"
              placeholder="Search for a lesson..."
            />
          </div>

          <button className="apply-button">
            Search
          </button>

        </section>

        <div className="group-container">
          <button className="group-button">
            ◉ Group by Department
          </button>
        </div>

        <LessonGrid lessons={lessons} />

      </main>
    </>
  );
}

export default LessonsPage;