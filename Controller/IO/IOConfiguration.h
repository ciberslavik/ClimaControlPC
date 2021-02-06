#pragma once

#include <QObject>

class IOConfiguration : public QObject
{
	Q_OBJECT

public:
	IOConfiguration(QObject *parent);
	~IOConfiguration();
};
