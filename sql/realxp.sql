/*
Navicat MySQL Data Transfer

Source Server         : Local
Source Server Version : 50524
Source Host           : localhost:3306
Source Database       : realxp

Target Server Type    : MYSQL
Target Server Version : 50524
File Encoding         : 65001

Date: 2014-03-30 17:10:25
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `cameras`
-- ----------------------------
DROP TABLE IF EXISTS `cameras`;
CREATE TABLE `cameras` (
  `camera_id` int(11) NOT NULL AUTO_INCREMENT,
  `camera_brand` varchar(50) NOT NULL,
  `camera_model` varchar(50) NOT NULL,
  `camera_max_seats` int(10) NOT NULL,
  `camera_resolution_x` int(5) NOT NULL COMMENT 'At maximum resolution',
  `camera_resolution_y` int(5) NOT NULL COMMENT 'At maximum resolution',
  `camera_has_audio` tinyint(1) NOT NULL,
  `camera_fps` int(3) NOT NULL COMMENT 'At maximum video resolution',
  PRIMARY KEY (`camera_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of cameras
-- ----------------------------

-- ----------------------------
-- Table structure for `events`
-- ----------------------------
DROP TABLE IF EXISTS `events`;
CREATE TABLE `events` (
  `event_id` int(11) NOT NULL AUTO_INCREMENT,
  `venue_id` int(11) NOT NULL,
  `event_start_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `event_end_time` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `event_name` varchar(255) NOT NULL,
  PRIMARY KEY (`event_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of events
-- ----------------------------

-- ----------------------------
-- Table structure for `event_seats`
-- ----------------------------
DROP TABLE IF EXISTS `event_seats`;
CREATE TABLE `event_seats` (
  `event_seat_id` int(11) NOT NULL,
  `event_id` int(11) NOT NULL,
  `seat_id` int(11) NOT NULL,
  `event_seat_sell_capacity` int(10) NOT NULL,
  `event_seat_price` decimal(12,2) NOT NULL,
  PRIMARY KEY (`event_seat_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of event_seats
-- ----------------------------

-- ----------------------------
-- Table structure for `seats`
-- ----------------------------
DROP TABLE IF EXISTS `seats`;
CREATE TABLE `seats` (
  `seat_id` int(11) NOT NULL,
  `camera_id` int(11) NOT NULL,
  `venue_id` int(11) NOT NULL,
  `seat_capacity` int(10) NOT NULL,
  `seat_number` int(4) DEFAULT NULL,
  `seat_row` varchar(50) DEFAULT NULL,
  `seat_section` varchar(50) DEFAULT NULL,
  `seat_description` varchar(200) DEFAULT NULL,
  `seat_sample_view` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`seat_id`),
  KEY `venue_id` (`venue_id`),
  CONSTRAINT `seats_ibfk_1` FOREIGN KEY (`venue_id`) REFERENCES `venues` (`venue_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of seats
-- ----------------------------

-- ----------------------------
-- Table structure for `venues`
-- ----------------------------
DROP TABLE IF EXISTS `venues`;
CREATE TABLE `venues` (
  `venue_id` int(11) NOT NULL AUTO_INCREMENT,
  `venue_name` varchar(100) NOT NULL,
  `venue_coords` point DEFAULT NULL,
  `venue_country` varchar(100) NOT NULL,
  `venue_city` varchar(100) NOT NULL,
  `venue_state` varchar(50) NOT NULL,
  `venue_address_1` varchar(100) NOT NULL,
  `venue_address_2` varchar(100) DEFAULT NULL,
  `venue_address_3` varchar(100) DEFAULT NULL,
  `venue_postcode` varchar(10) NOT NULL,
  PRIMARY KEY (`venue_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of venues
-- ----------------------------
