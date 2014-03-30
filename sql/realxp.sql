/*
Navicat MySQL Data Transfer

Source Server         : Mikes Laptop
Source Server Version : 50535
Source Host           : 192.168.233.153:3306
Source Database       : realxp

Target Server Type    : MYSQL
Target Server Version : 50535
File Encoding         : 65001

Date: 2014-03-31 00:21:48
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for cameras
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
-- Table structure for event_seats
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
-- Table structure for events
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
-- Table structure for payment_methods
-- ----------------------------
DROP TABLE IF EXISTS `payment_methods`;
CREATE TABLE `payment_methods` (
  `payment_method_id` int(11) NOT NULL,
  `payment_method_name` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`payment_method_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of payment_methods
-- ----------------------------

-- ----------------------------
-- Table structure for payments
-- ----------------------------
DROP TABLE IF EXISTS `payments`;
CREATE TABLE `payments` (
  `payment_id` int(11) NOT NULL,
  `payment_method_id` int(11) NOT NULL,
  `payment_successful` tinyint(1) NOT NULL,
  `payment_gateway_transaction_reference` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`payment_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of payments
-- ----------------------------

-- ----------------------------
-- Table structure for seats
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
-- Table structure for user_addresses
-- ----------------------------
DROP TABLE IF EXISTS `user_addresses`;
CREATE TABLE `user_addresses` (
  `user_address_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `user_address_name` varchar(100) NOT NULL,
  `user_address_country` varchar(100) NOT NULL,
  `user_address_city` varchar(100) NOT NULL,
  `user_address_state` varchar(50) NOT NULL,
  `user_address_line1` varchar(100) NOT NULL,
  `user_address_line2` varchar(100) NOT NULL,
  `user_address_line3` varchar(100) DEFAULT NULL,
  `user_address_line4` varchar(100) DEFAULT NULL,
  `user_address_postcode` varchar(10) NOT NULL,
  PRIMARY KEY (`user_address_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of user_addresses
-- ----------------------------

-- ----------------------------
-- Table structure for user_logs
-- ----------------------------
DROP TABLE IF EXISTS `user_logs`;
CREATE TABLE `user_logs` (
  `user_logs_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `users_logs_action` varchar(255) NOT NULL,
  `users_logs_timestamp` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`user_logs_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of user_logs
-- ----------------------------

-- ----------------------------
-- Table structure for user_purchases
-- ----------------------------
DROP TABLE IF EXISTS `user_purchases`;
CREATE TABLE `user_purchases` (
  `user_purchase_id` int(11) NOT NULL,
  `event_seats_id` int(11) NOT NULL,
  `payment_id` int(11) NOT NULL,
  `user_purchase_timestamp` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`user_purchase_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of user_purchases
-- ----------------------------

-- ----------------------------
-- Table structure for users
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `user_id` int(11) NOT NULL,
  `user_email` varchar(255) NOT NULL,
  `user_password_hash` varchar(255) NOT NULL,
  `user_password_salt` varchar(255) NOT NULL,
  `user_firstname` varchar(100) NOT NULL,
  `user_lastname` varchar(100) NOT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of users
-- ----------------------------

-- ----------------------------
-- Table structure for venue_reviews
-- ----------------------------
DROP TABLE IF EXISTS `venue_reviews`;
CREATE TABLE `venue_reviews` (
  `venue_review_id` int(11) NOT NULL,
  `venue_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `venue_review_review` varchar(255) NOT NULL,
  `venue_review_rating` int(3) NOT NULL,
  PRIMARY KEY (`venue_review_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of venue_reviews
-- ----------------------------

-- ----------------------------
-- Table structure for venues
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
