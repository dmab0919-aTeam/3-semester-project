# Image
FROM node:12.4-alpine

RUN mkdir /app
WORKDIR /app

COPY package*.json ./
RUN npm install

# Init command
CMD ["npm", "run", "serve"]