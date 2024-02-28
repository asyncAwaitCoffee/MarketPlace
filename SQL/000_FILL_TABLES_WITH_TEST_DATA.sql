TRUNCATE TABLE MARKET_PLACE.MARKET_ITEMS
ALTER SEQUENCE MARKET_PLACE.MARKET_ITEMS_SEQ RESTART

INSERT INTO MARKET_PLACE.MARKET_ITEMS (TITLE, ITEM_DESCRIPTION, ITEM_CATEGORY, START_PRICE, END_PRICE, CURRENT_PRICE, BID_STEP, DATE_START, DATE_END, HIGHEST_BIDDER, OWNER_ID)
VALUES 
('Smartphone', 'Brand new smartphone with latest features', 1, 500.00, NULL, NULL, NULL, '2024-02-27 10:00:00', '2024-03-05 10:00:00', 0, 101),
('Laptop', 'Powerful laptop suitable for gaming and work', 2, 1200.00, NULL, NULL, NULL, '2024-02-28 09:00:00', '2024-03-07 09:00:00', 0, 102),
('Watch', 'Elegant wristwatch made of stainless steel', 3, 300.00, NULL, NULL, NULL, '2024-02-29 08:00:00', '2024-03-06 08:00:00', 0, 103),
('Headphones', 'Wireless noise-canceling headphones with long battery life', 4, 150.00, NULL, NULL, NULL, '2024-03-01 07:00:00', '2024-03-08 07:00:00', 0, 104),
('Camera', 'Professional DSLR camera with multiple lenses', 5, 800.00, NULL, NULL, NULL, '2024-03-02 06:00:00', '2024-03-09 06:00:00', 0, 105);