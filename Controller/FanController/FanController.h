#pragma once

#include <QObject>

class FanController : public QObject
{
	Q_OBJECT

public:
	FanController(QObject *parent);
	~FanController();
};
