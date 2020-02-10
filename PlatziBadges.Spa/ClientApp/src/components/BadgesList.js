import React, { useState, useMemo } from "react";
import { Link } from "react-router-dom";

import "./styles/BadgesList.css";
import BadgeListItem from "../components/BadgeListItem";

function useBadgeFilter(badges) {
  const [word, setWord] = useState("");
  const [filterBadges, setFilterBadges] = useState(badges);

  useMemo(() => {
    var result = badges.filter(badge => {
      return `${badge.firstName} ${badge.lastName}`
        .toLowerCase()
        .includes(word.toLowerCase());
    });

    setFilterBadges(result);
  }, [badges, word]);

  return [word, filterBadges, setWord];
}

function BadgeList(props) {
  const badges = props.badges;
  const [word, filterBadges, setWord] = useBadgeFilter(badges);

  if (filterBadges.length === 0) {
    return (
      <div>
        <div className="form-group">
          <label>Filter Badges</label>
          <input
            type="text"
            className="form-control"
            value={word}
            onChange={e => {
              setWord(e.target.value);
            }}
          />
        </div>
        <h3>No badges were found</h3>
        <Link className="btn btn-secondary" to="/badges/new">
          Create new badge
        </Link>
      </div>
    );
  }

  return (
    <div className="BadgesList">
      <div className="form-group">
        <label>Filter Badges</label>
        <input
          type="text"
          className="form-control"
          value={word}
          onChange={e => {
            setWord(e.target.value);
          }}
        />
      </div>
      <ul className="list-unstyled">
        {filterBadges.map((badge, i) => {
          return (
            <li
              key={i}
              data-id={badge.badgeId}
              onClick={() => props.redirectEdit(badge.badgeId)}
              className="BadgesListItem"
            >
              <BadgeListItem badge={badge} />
            </li>
          );
        })}
      </ul>
    </div>
  );
}

export default BadgeList;
