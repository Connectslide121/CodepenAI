import React, { useContext, useEffect, useState } from "react";
import { GetProjectsByUserId } from "../APIs/API";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTrashCan } from "@fortawesome/free-solid-svg-icons";
import { CurrentUserContext } from "../functions/contexts";

export default function ProjectList(props) {
  const { currentUser } = useContext(CurrentUserContext);

  const [projectList, setProjectList] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      const projects = await GetProjectsByUserId(currentUser.userId);
      setProjectList(projects);
    };

    fetchData();
  }, [props.rerenderKey, currentUser]);

  const formatDate = (dateString) => {
    const options = { day: "numeric", month: "short", year: "numeric" };
    return new Date(dateString).toLocaleDateString(undefined, options);
  };

  return (
    <>
      <div className="project-list-wrapper">
        <div className="project-list-header">
          <div className="project-title">Title</div>
          <div className="project-description">Description</div>
          <div className="project-date">Created</div>
          <div className="project-update-date">Updated</div>
          <div className="spacer"></div>
        </div>

        <ul>
          {projectList.map((project) => (
            <div key={project.projectId} className="project-list-item">
              <li
                title="Open project"
                onClick={() => props.openProject(project.projectId)}
              >
                <div className="project-title">{project.title}</div>
                <div className="project-description">{project.description}</div>
                <div className="project-date">
                  {formatDate(project.createdAt)}
                </div>
                <div className="project-update-date">
                  {formatDate(project.updatedAt)}
                </div>
              </li>
              <div
                title="Delete project"
                className="delete-project-button"
                onClick={() => props.deleteProject(project.projectId)}
              >
                <FontAwesomeIcon icon={faTrashCan} />
              </div>
            </div>
          ))}
        </ul>
      </div>
    </>
  );
}
